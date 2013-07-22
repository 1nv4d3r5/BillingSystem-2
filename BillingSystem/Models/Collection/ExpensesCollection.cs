using FBJHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace BillingSystem.Models
{
    [Serializable]
    public sealed class ExpensesCollection : CollectionBase
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
        public ExpensesCollection() { }

        /// <summary>
        /// Constructor using CcZlCzBillInfo array.
        /// </summary>
        /// <param name="value" />
        public ExpensesCollection(ExpensesInfo[] value)
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
            sb.Append("<ExpensesInfo>");
            for (int i = 0; i < this.Count; i++)
            {
                sb.Append(this[i].ToXmlTree());
            }
            sb.Append("</ExpensesInfo>");
            return sb.ToString();
        }

        public string Serialize()
        {
            XmlSerializer s = new XmlSerializer(typeof(ExpensesCollection));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static ExpensesCollection DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(ExpensesCollection));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as ExpensesCollection;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public ExpensesInfo this[int index]
        {
            get
            {
                return (ExpensesInfo)this.List[index];
            }
        }

        public int Add(ExpensesInfo value)
        {
            return this.List.Add(value);
        }

        public void AddRange(ExpensesInfo[] value)
        {
            for (int i = 0; (i < value.Length); i++)
            {
                this.Add(value[i]);
            }
        }

        public void AddRange(ExpensesCollection value)
        {
            for (int i = 0; (i < value.Count); i++)
            {
                this.Add(value.List[i] as ExpensesInfo);
            }
        }

        public bool Contains(ExpensesInfo value)
        {
            if (IndexOf(value) > -1)
                return true;

            return false;
        }

        public void CopyTo(ExpensesInfo[] array, int index)
        {
            this.List.CopyTo(array, index);
        }

        public int IndexOf(ExpensesInfo value)
        {
            for (int i = 0, count = this.List.Count; i < count; i++)
            {
                if (value.Equals(this.List[i] as ExpensesInfo))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, ExpensesInfo value)
        {
            List.Insert(index, value);

            innerListChanged = true;
        }

        public void Remove(ExpensesInfo value)
        {
            List.Remove(value);

            innerListChanged = true;
        }

        public ExpensesInfo Get(long id)
        {
            if (indexerForPrimaryKeys == null || innerListChanged)
            {
                innerListChanged = false;

                indexerForPrimaryKeys = new Dictionary<string, int>();

                for (int i = 0, count = this.List.Count; i < count; i++)
                {
                    ExpensesInfo expensesInfo = this.List[i] as ExpensesInfo;

                    indexerForPrimaryKeys.Add(string.Concat(expensesInfo.Id.ToString()), i);
                }
            }

            int index;

            if (indexerForPrimaryKeys.TryGetValue(string.Concat(id.ToString()), out index))
            {
                return this.List[index] as ExpensesInfo;
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

        public ExpensesCollection Pagination(int pageIndex, int pageSize)
        {
            if (InnerList.Count == 0)
                return null;

            int start = pageSize * (pageIndex - 1);
            int end = start + pageSize - 1;

            if (end > InnerList.Count - 1)
                end = InnerList.Count - 1;

            ExpensesCollection pages = new ExpensesCollection();

            for (int i = start; i <= end; i++)
            {
                pages.Add(InnerList[i] as ExpensesInfo);
            }

            return pages;
        }

        public void Sort()
        {
            this.InnerList.Sort(new ExpensesCollectionComparer());
        }

        public void Sort(int sortBy)
        {
            this.InnerList.Sort(new ExpensesCollectionComparer(sortBy));
        }

        public void Sort(ExpensesSortBy sortBy)
        {
            this.InnerList.Sort(new ExpensesCollectionComparer(sortBy));
        }

        #endregion

        #region Enum ExpensesSortBy

        public enum ExpensesSortBy
        {
            IdOrderByAsc,
            IdOrderByDesc
        }

        #endregion

        #region Class CardCollectionComparer

        private sealed class ExpensesCollectionComparer : IComparer
        {
            private ExpensesSortBy sortBy;

            public ExpensesCollectionComparer() { }

            public ExpensesCollectionComparer(ExpensesSortBy sortBy)
            {
                this.sortBy = sortBy;
            }

            public ExpensesCollectionComparer(int sortBy)
            {
                this.sortBy = (ExpensesSortBy)sortBy;
            }

            public int Compare(object x, object y)
            {
                switch (sortBy)
                {
                    case ExpensesSortBy.IdOrderByAsc:
                        return (x as ExpensesInfo).Id.CompareTo((y as ExpensesInfo).Id);
                    case ExpensesSortBy.IdOrderByDesc:
                        return (y as ExpensesInfo).Id.CompareTo((x as ExpensesInfo).Id);
                    default:
                        return ((ExpensesInfo)x).Id.CompareTo(((ExpensesInfo)y).Id);
                }
            }
        }

        #endregion

        #region Class CcZlCzBillCollectionEnumerator

        public new ExpensesCollectionEnumerator GetEnumerator()
        {
            return new ExpensesCollectionEnumerator(this);
        }

        public class ExpensesCollectionEnumerator : IEnumerator
        {
            private IEnumerator enumerator;

            public ExpensesCollectionEnumerator(ExpensesCollection mappings)
            {
                enumerator = ((IEnumerable)mappings).GetEnumerator();
            }

            public ExpensesInfo Current
            {
                get
                {
                    return (ExpensesInfo)enumerator.Current;
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