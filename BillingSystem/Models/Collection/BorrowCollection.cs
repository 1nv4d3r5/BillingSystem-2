using FBJHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace BillingSystem.Models
{
    [Serializable]
    public sealed class BorrowCollection : CollectionBase
    {
        #region Private Fields

        private int totalCount = 0;
        private bool innerListChanged = false;
        private Dictionary<string, int> indexerForPrimaryKeys;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BorrowCollection() { }

        /// <summary>
        /// Constructor using CcZlCzBillInfo array.
        /// </summary>
        /// <param name="value" />
        public BorrowCollection(BorrowInfo[] value)
        {
            this.AddRange(value);
        }

        #endregion

        #region Public Properties

        public int TotalCount
        {
            get { return totalCount; }
            set { totalCount = value; }
        }

        #endregion

        #region Public Methods

        public string ToJson()
        {
            StringBuilder jsonStringBuilder = new StringBuilder();

            jsonStringBuilder.Append("{");

            jsonStringBuilder.Append("TotalCount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.totalCount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("List:");
            jsonStringBuilder.Append("[");

            int count = this.List.Count;

            for (int i = 0; i < count; i++)
            {
                FbjJsonHelper.WriteValue(jsonStringBuilder, this.List[i]);
                jsonStringBuilder.Append(",");
            }

            if (count > 0)
            {
                --jsonStringBuilder.Length;
            }

            jsonStringBuilder.Append("]");
            jsonStringBuilder.Append("}");

            return jsonStringBuilder.ToString();
        }

        public string ToXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<BorrowInfo>");
            for (int i = 0; i < this.Count; i++)
            {
                sb.Append(this[i].ToXmlTree());
            }
            sb.Append("</BorrowInfo>");
            return sb.ToString();
        }

        public string Serialize()
        {
            XmlSerializer s = new XmlSerializer(typeof(BorrowCollection));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static BorrowCollection DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(BorrowCollection));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as BorrowCollection;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public BorrowInfo this[int index]
        {
            get
            {
                return (BorrowInfo)this.List[index];
            }
        }

        public int Add(BorrowInfo value)
        {
            return this.List.Add(value);
        }

        public void AddRange(BorrowInfo[] value)
        {
            for (int i = 0; (i < value.Length); i++)
            {
                this.Add(value[i]);
            }
        }

        public void AddRange(BorrowCollection value)
        {
            for (int i = 0; (i < value.Count); i++)
            {
                this.Add(value.List[i] as BorrowInfo);
            }
        }

        public bool Contains(BorrowInfo value)
        {
            if (IndexOf(value) > -1)
                return true;

            return false;
        }

        public void CopyTo(BorrowInfo[] array, int index)
        {
            this.List.CopyTo(array, index);
        }

        public int IndexOf(BorrowInfo value)
        {
            for (int i = 0, count = this.List.Count; i < count; i++)
            {
                if (value.Equals(this.List[i] as BorrowInfo))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, BorrowInfo value)
        {
            List.Insert(index, value);

            innerListChanged = true;
        }

        public void Remove(BorrowInfo value)
        {
            List.Remove(value);

            innerListChanged = true;
        }

        public BorrowInfo Get(long id)
        {
            if (indexerForPrimaryKeys == null || innerListChanged)
            {
                innerListChanged = false;

                indexerForPrimaryKeys = new Dictionary<string, int>();

                for (int i = 0, count = this.List.Count; i < count; i++)
                {
                    BorrowInfo borrowInfo = this.List[i] as BorrowInfo;

                    indexerForPrimaryKeys.Add(string.Concat(borrowInfo.Id.ToString()), i);
                }
            }

            int index;

            if (indexerForPrimaryKeys.TryGetValue(string.Concat(id.ToString()), out index))
            {
                return this.List[index] as BorrowInfo;
            }
            else
            {
                return null;
            }
        }

        public int TotalPages(int pageSize)
        {
            int totalPagesAvailable;

            if (InnerList.Count == 0)
                return 1;

            totalPagesAvailable = InnerList.Count / pageSize;

            if ((InnerList.Count % pageSize) > 0)
                totalPagesAvailable++;

            return totalPagesAvailable;
        }

        public BorrowCollection Pagination(int pageIndex, int pageSize)
        {
            if (InnerList.Count == 0)
                return null;

            int start = pageSize * (pageIndex - 1);
            int end = start + pageSize - 1;

            if (end > InnerList.Count - 1)
                end = InnerList.Count - 1;

            BorrowCollection pages = new BorrowCollection();

            for (int i = start; i <= end; i++)
            {
                pages.Add(InnerList[i] as BorrowInfo);
            }

            return pages;
        }

        public void Sort()
        {
            this.InnerList.Sort(new BorrowCollectionComparer());
        }

        public void Sort(int sortBy)
        {
            this.InnerList.Sort(new BorrowCollectionComparer(sortBy));
        }

        public void Sort(BorrowSortBy sortBy)
        {
            this.InnerList.Sort(new BorrowCollectionComparer(sortBy));
        }

        #endregion

        #region Enum BorrowSortBy

        public enum BorrowSortBy
        {
            IdOrderByAsc,
            IdOrderByDesc
        }

        #endregion

        #region Class BorrowCollectionComparer

        private sealed class BorrowCollectionComparer : IComparer
        {
            private BorrowSortBy sortBy;

            public BorrowCollectionComparer() { }

            public BorrowCollectionComparer(BorrowSortBy sortBy)
            {
                this.sortBy = sortBy;
            }

            public BorrowCollectionComparer(int sortBy)
            {
                this.sortBy = (BorrowSortBy)sortBy;
            }

            public int Compare(object x, object y)
            {
                switch (sortBy)
                {
                    case BorrowSortBy.IdOrderByAsc:
                        return (x as BorrowInfo).Id.CompareTo((y as BorrowInfo).Id);
                    case BorrowSortBy.IdOrderByDesc:
                        return (y as BorrowInfo).Id.CompareTo((x as BorrowInfo).Id);
                    default:
                        return ((BorrowInfo)x).Id.CompareTo(((BorrowInfo)y).Id);
                }
            }
        }

        #endregion

        #region Class CcZlCzBillCollectionEnumerator

        public new BorrowCollectionEnumerator GetEnumerator()
        {
            return new BorrowCollectionEnumerator(this);
        }

        public class BorrowCollectionEnumerator : IEnumerator
        {
            private IEnumerator enumerator;

            public BorrowCollectionEnumerator(BorrowCollection mappings)
            {
                enumerator = ((IEnumerable)mappings).GetEnumerator();
            }

            public BorrowInfo Current
            {
                get
                {
                    return (BorrowInfo)enumerator.Current;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return enumerator.Current;
                }
            }

            public bool MoveNext()
            {
                return enumerator.MoveNext();
            }

            bool IEnumerator.MoveNext()
            {
                return enumerator.MoveNext();
            }

            public void Reset()
            {
                enumerator.Reset();
            }

            void IEnumerator.Reset()
            {
                enumerator.Reset();
            }
        }

        #endregion
    }
}