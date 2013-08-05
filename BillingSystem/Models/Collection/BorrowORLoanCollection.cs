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
    public sealed class BorrowORLoanCollection : CollectionBase
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
        public BorrowORLoanCollection() { }

        /// <summary>
        /// Constructor using CcZlCzBillInfo array.
        /// </summary>
        /// <param name="value" />
        public BorrowORLoanCollection(BorrowORLoanInfo[] value)
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
            XmlSerializer s = new XmlSerializer(typeof(BorrowORLoanCollection));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static BorrowORLoanCollection DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(BorrowORLoanCollection));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as BorrowORLoanCollection;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public BorrowORLoanInfo this[int index]
        {
            get
            {
                return (BorrowORLoanInfo)this.List[index];
            }
        }

        public int Add(BorrowORLoanInfo value)
        {
            return this.List.Add(value);
        }

        public void AddRange(BorrowORLoanInfo[] value)
        {
            for (int i = 0; (i < value.Length); i++)
            {
                this.Add(value[i]);
            }
        }

        public void AddRange(BorrowORLoanCollection value)
        {
            for (int i = 0; (i < value.Count); i++)
            {
                this.Add(value.List[i] as BorrowORLoanInfo);
            }
        }

        public bool Contains(BorrowORLoanInfo value)
        {
            if (IndexOf(value) > -1)
                return true;

            return false;
        }

        public void CopyTo(BorrowORLoanInfo[] array, int index)
        {
            this.List.CopyTo(array, index);
        }

        public int IndexOf(BorrowORLoanInfo value)
        {
            for (int i = 0, count = this.List.Count; i < count; i++)
            {
                if (value.Equals(this.List[i] as BorrowORLoanInfo))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, BorrowORLoanInfo value)
        {
            List.Insert(index, value);

            innerListChanged = true;
        }

        public void Remove(BorrowORLoanInfo value)
        {
            List.Remove(value);

            innerListChanged = true;
        }

        public BorrowORLoanInfo Get(long id)
        {
            if (indexerForPrimaryKeys == null || innerListChanged)
            {
                innerListChanged = false;

                indexerForPrimaryKeys = new Dictionary<string, int>();

                for (int i = 0, count = this.List.Count; i < count; i++)
                {
                    BorrowORLoanInfo borrowInfo = this.List[i] as BorrowORLoanInfo;

                    indexerForPrimaryKeys.Add(string.Concat(borrowInfo.Id.ToString()), i);
                }
            }

            int index;

            if (indexerForPrimaryKeys.TryGetValue(string.Concat(id.ToString()), out index))
            {
                return this.List[index] as BorrowORLoanInfo;
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

        public BorrowORLoanCollection Pagination(int pageIndex, int pageSize)
        {
            if (InnerList.Count == 0)
                return null;

            int start = pageSize * (pageIndex - 1);
            int end = start + pageSize - 1;

            if (end > InnerList.Count - 1)
                end = InnerList.Count - 1;

            BorrowORLoanCollection pages = new BorrowORLoanCollection();

            for (int i = start; i <= end; i++)
            {
                pages.Add(InnerList[i] as BorrowORLoanInfo);
            }

            return pages;
        }

        public void Sort()
        {
            this.InnerList.Sort(new BorrowORLoanCollectionComparer());
        }

        public void Sort(int sortBy)
        {
            this.InnerList.Sort(new BorrowORLoanCollectionComparer(sortBy));
        }

        public void Sort(BorrowSortBy sortBy)
        {
            this.InnerList.Sort(new BorrowORLoanCollectionComparer(sortBy));
        }

        #endregion

        #region Enum BorrowSortBy

        public enum BorrowSortBy
        {
            IdOrderByAsc,
            IdOrderByDesc
        }

        #endregion

        #region Class BorrowORLoanCollectionComparer

        private sealed class BorrowORLoanCollectionComparer : IComparer
        {
            private BorrowSortBy sortBy;

            public BorrowORLoanCollectionComparer() { }

            public BorrowORLoanCollectionComparer(BorrowSortBy sortBy)
            {
                this.sortBy = sortBy;
            }

            public BorrowORLoanCollectionComparer(int sortBy)
            {
                this.sortBy = (BorrowSortBy)sortBy;
            }

            public int Compare(object x, object y)
            {
                switch (sortBy)
                {
                    case BorrowSortBy.IdOrderByAsc:
                        return (x as BorrowORLoanInfo).Id.CompareTo((y as BorrowORLoanInfo).Id);
                    case BorrowSortBy.IdOrderByDesc:
                        return (y as BorrowORLoanInfo).Id.CompareTo((x as BorrowORLoanInfo).Id);
                    default:
                        return ((BorrowORLoanInfo)x).Id.CompareTo(((BorrowORLoanInfo)y).Id);
                }
            }
        }

        #endregion

        #region Class CcZlCzBillCollectionEnumerator

        public new BorrowORLoanCollectionEnumerator GetEnumerator()
        {
            return new BorrowORLoanCollectionEnumerator(this);
        }

        public class BorrowORLoanCollectionEnumerator : IEnumerator
        {
            private IEnumerator enumerator;

            public BorrowORLoanCollectionEnumerator(BorrowORLoanCollection mappings)
            {
                enumerator = ((IEnumerable)mappings).GetEnumerator();
            }

            public BorrowORLoanInfo Current
            {
                get
                {
                    return (BorrowORLoanInfo)enumerator.Current;
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