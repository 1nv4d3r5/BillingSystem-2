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
    public sealed class LoanCollection : CollectionBase
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
        public LoanCollection() { }

        /// <summary>
        /// Constructor using CcZlCzBillInfo array.
        /// </summary>
        /// <param name="value" />
        public LoanCollection(LoanInfo[] value)
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
            sb.Append("<LoanInfo>");
            for (int i = 0; i < this.Count; i++)
            {
                sb.Append(this[i].ToXmlTree());
            }
            sb.Append("</LoanInfo>");
            return sb.ToString();
        }

        public string Serialize()
        {
            XmlSerializer s = new XmlSerializer(typeof(LoanCollection));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static LoanCollection DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(LoanCollection));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as LoanCollection;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public LoanInfo this[int index]
        {
            get
            {
                return (LoanInfo)this.List[index];
            }
        }

        public int Add(LoanInfo value)
        {
            return this.List.Add(value);
        }

        public void AddRange(LoanInfo[] value)
        {
            for (int i = 0; (i < value.Length); i++)
            {
                this.Add(value[i]);
            }
        }

        public void AddRange(LoanCollection value)
        {
            for (int i = 0; (i < value.Count); i++)
            {
                this.Add(value.List[i] as LoanInfo);
            }
        }

        public bool Contains(LoanInfo value)
        {
            if (IndexOf(value) > -1)
                return true;

            return false;
        }

        public void CopyTo(LoanInfo[] array, int index)
        {
            this.List.CopyTo(array, index);
        }

        public int IndexOf(LoanInfo value)
        {
            for (int i = 0, count = this.List.Count; i < count; i++)
            {
                if (value.Equals(this.List[i] as LoanInfo))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, LoanInfo value)
        {
            List.Insert(index, value);

            innerListChanged = true;
        }

        public void Remove(LoanInfo value)
        {
            List.Remove(value);

            innerListChanged = true;
        }

        public LoanInfo Get(long id)
        {
            if (indexerForPrimaryKeys == null || innerListChanged)
            {
                innerListChanged = false;

                indexerForPrimaryKeys = new Dictionary<string, int>();

                for (int i = 0, count = this.List.Count; i < count; i++)
                {
                    LoanInfo loanInfo = this.List[i] as LoanInfo;

                    indexerForPrimaryKeys.Add(string.Concat(loanInfo.Id.ToString()), i);
                }
            }

            int index;

            if (indexerForPrimaryKeys.TryGetValue(string.Concat(id.ToString()), out index))
            {
                return this.List[index] as LoanInfo;
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

        public LoanCollection Pagination(int pageIndex, int pageSize)
        {
            if (InnerList.Count == 0)
                return null;

            int start = pageSize * (pageIndex - 1);
            int end = start + pageSize - 1;

            if (end > InnerList.Count - 1)
                end = InnerList.Count - 1;

            LoanCollection pages = new LoanCollection();

            for (int i = start; i <= end; i++)
            {
                pages.Add(InnerList[i] as LoanInfo);
            }

            return pages;
        }

        public void Sort()
        {
            this.InnerList.Sort(new LoanCollectionComparer());
        }

        public void Sort(int sortBy)
        {
            this.InnerList.Sort(new LoanCollectionComparer(sortBy));
        }

        public void Sort(BorrowSortBy sortBy)
        {
            this.InnerList.Sort(new LoanCollectionComparer(sortBy));
        }

        #endregion

        #region Enum BorrowSortBy

        public enum BorrowSortBy
        {
            IdOrderByAsc,
            IdOrderByDesc
        }

        #endregion

        #region Class LoanCollectionComparer

        private sealed class LoanCollectionComparer : IComparer
        {
            private BorrowSortBy sortBy;

            public LoanCollectionComparer() { }

            public LoanCollectionComparer(BorrowSortBy sortBy)
            {
                this.sortBy = sortBy;
            }

            public LoanCollectionComparer(int sortBy)
            {
                this.sortBy = (BorrowSortBy)sortBy;
            }

            public int Compare(object x, object y)
            {
                switch (sortBy)
                {
                    case BorrowSortBy.IdOrderByAsc:
                        return (x as LoanInfo).Id.CompareTo((y as LoanInfo).Id);
                    case BorrowSortBy.IdOrderByDesc:
                        return (y as LoanInfo).Id.CompareTo((x as LoanInfo).Id);
                    default:
                        return ((LoanInfo)x).Id.CompareTo(((LoanInfo)y).Id);
                }
            }
        }

        #endregion

        #region Class CcZlCzBillCollectionEnumerator

        public new LoanCollectionEnumerator GetEnumerator()
        {
            return new LoanCollectionEnumerator(this);
        }

        public class LoanCollectionEnumerator : IEnumerator
        {
            private IEnumerator enumerator;

            public LoanCollectionEnumerator(LoanCollection mappings)
            {
                enumerator = ((IEnumerable)mappings).GetEnumerator();
            }

            public LoanInfo Current
            {
                get
                {
                    return (LoanInfo)enumerator.Current;
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