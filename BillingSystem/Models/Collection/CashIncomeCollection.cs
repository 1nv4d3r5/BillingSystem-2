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
    public sealed class CashIncomeCollection : CollectionBase
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
        public CashIncomeCollection() { }

        /// <summary>
        /// Constructor using CcZlCzBillInfo array.
        /// </summary>
        /// <param name="value" />
        public CashIncomeCollection(CashIncomeInfo[] value)
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
            sb.Append("<CashIncomeInfo>");
            for (int i = 0; i < this.Count; i++)
            {
                sb.Append(this[i].ToXmlTree());
            }
            sb.Append("</CashIncomeInfo>");
            return sb.ToString();
        }

        public string Serialize()
        {
            XmlSerializer s = new XmlSerializer(typeof(CashIncomeCollection));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static CashIncomeCollection DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(CashIncomeCollection));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as CashIncomeCollection;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public CashIncomeInfo this[int index]
        {
            get
            {
                return (CashIncomeInfo)this.List[index];
            }
        }

        public int Add(CashIncomeInfo value)
        {
            return this.List.Add(value);
        }

        public void AddRange(CashIncomeInfo[] value)
        {
            for (int i = 0; (i < value.Length); i++)
            {
                this.Add(value[i]);
            }
        }

        public void AddRange(CashIncomeCollection value)
        {
            for (int i = 0; (i < value.Count); i++)
            {
                this.Add(value.List[i] as CashIncomeInfo);
            }
        }

        public bool Contains(CashIncomeInfo value)
        {
            if (IndexOf(value) > -1)
                return true;

            return false;
        }

        public void CopyTo(CashIncomeInfo[] array, int index)
        {
            this.List.CopyTo(array, index);
        }

        public int IndexOf(CashIncomeInfo value)
        {
            for (int i = 0, count = this.List.Count; i < count; i++)
            {
                if (value.Equals(this.List[i] as CashIncomeInfo))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, CashIncomeInfo value)
        {
            List.Insert(index, value);

            innerListChanged = true;
        }

        public void Remove(CashIncomeInfo value)
        {
            List.Remove(value);

            innerListChanged = true;
        }

        public CashIncomeInfo Get(long id)
        {
            if (indexerForPrimaryKeys == null || innerListChanged)
            {
                innerListChanged = false;

                indexerForPrimaryKeys = new Dictionary<string, int>();

                for (int i = 0, count = this.List.Count; i < count; i++)
                {
                    CashIncomeInfo cashIncomeInfo = this.List[i] as CashIncomeInfo;

                    indexerForPrimaryKeys.Add(string.Concat(cashIncomeInfo.Id.ToString()), i);
                }
            }

            int index;

            if (indexerForPrimaryKeys.TryGetValue(string.Concat(id.ToString()), out index))
            {
                return this.List[index] as CashIncomeInfo;
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

        public CashIncomeCollection Pagination(int pageIndex, int pageSize)
        {
            if (InnerList.Count == 0)
                return null;

            int start = pageSize * (pageIndex - 1);
            int end = start + pageSize - 1;

            if (end > InnerList.Count - 1)
                end = InnerList.Count - 1;

            CashIncomeCollection pages = new CashIncomeCollection();

            for (int i = start; i <= end; i++)
            {
                pages.Add(InnerList[i] as CashIncomeInfo);
            }

            return pages;
        }

        public void Sort()
        {
            this.InnerList.Sort(new CashIncomeCollectionComparer());
        }

        public void Sort(int sortBy)
        {
            this.InnerList.Sort(new CashIncomeCollectionComparer(sortBy));
        }

        public void Sort(CashIncomeSortBy sortBy)
        {
            this.InnerList.Sort(new CashIncomeCollectionComparer(sortBy));
        }

        #endregion

        #region Enum CardSortBy

        public enum CashIncomeSortBy
        {
            IdOrderByAsc,
            IdOrderByDesc
        }

        #endregion

        #region Class CashIncomeCollectionComparer

        private sealed class CashIncomeCollectionComparer : IComparer
        {
            private CashIncomeSortBy sortBy;

            public CashIncomeCollectionComparer() { }

            public CashIncomeCollectionComparer(CashIncomeSortBy sortBy)
            {
                this.sortBy = sortBy;
            }

            public CashIncomeCollectionComparer(int sortBy)
            {
                this.sortBy = (CashIncomeSortBy)sortBy;
            }

            public int Compare(object x, object y)
            {
                switch (sortBy)
                {
                    case CashIncomeSortBy.IdOrderByAsc:
                        return (x as CashIncomeInfo).Id.CompareTo((y as CashIncomeInfo).Id);
                    case CashIncomeSortBy.IdOrderByDesc:
                        return (y as CashIncomeInfo).Id.CompareTo((x as CashIncomeInfo).Id);
                    default:
                        return ((CashIncomeInfo)x).Id.CompareTo(((CashIncomeInfo)y).Id);
                }
            }
        }

        #endregion

        #region Class CashIncomeCollectionEnumerator

        public new CashIncomeCollectionEnumerator GetEnumerator()
        {
            return new CashIncomeCollectionEnumerator(this);
        }

        public class CashIncomeCollectionEnumerator : IEnumerator
        {
            private IEnumerator enumerator;

            public CashIncomeCollectionEnumerator(CashIncomeCollection mappings)
            {
                enumerator = ((IEnumerable)mappings).GetEnumerator();
            }

            public CashIncomeInfo Current
            {
                get
                {
                    return (CashIncomeInfo)enumerator.Current;
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