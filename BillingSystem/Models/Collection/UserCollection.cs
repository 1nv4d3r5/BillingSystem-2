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
    public sealed class UserCollection : CollectionBase
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
        public UserCollection() { }

        /// <summary>
        /// Constructor using CcZlCzBillInfo array.
        /// </summary>
        /// <param name="value" />
        public UserCollection(UserInfo[] value)
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
            sb.Append("<User>");
            for (int i = 0; i < this.Count; i++)
            {
                sb.Append(this[i].ToXmlTree());
            }
            sb.Append("</User>");
            return sb.ToString();
        }

        public string Serialize()
        {
            XmlSerializer s = new XmlSerializer(typeof(UserCollection));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static UserCollection DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(UserCollection));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as UserCollection;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public UserInfo this[int index]
        {
            get
            {
                return (UserInfo)this.List[index];
            }
        }

        public int Add(UserInfo value)
        {
            return this.List.Add(value);
        }

        public void AddRange(UserInfo[] value)
        {
            for (int i = 0; (i < value.Length); i++)
            {
                this.Add(value[i]);
            }
        }

        public void AddRange(UserCollection value)
        {
            for (int i = 0; (i < value.Count); i++)
            {
                this.Add(value.List[i] as UserInfo);
            }
        }

        public bool Contains(UserInfo value)
        {
            if (IndexOf(value) > -1)
                return true;

            return false;
        }

        public void CopyTo(UserInfo[] array, int index)
        {
            this.List.CopyTo(array, index);
        }

        public int IndexOf(UserInfo value)
        {
            for (int i = 0, count = this.List.Count; i < count; i++)
            {
                if (value.Equals(this.List[i] as UserInfo))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, UserInfo value)
        {
            List.Insert(index, value);

            innerListChanged = true;
        }

        public void Remove(UserInfo value)
        {
            List.Remove(value);

            innerListChanged = true;
        }

        public UserInfo Get(long id)
        {
            if (indexerForPrimaryKeys == null || innerListChanged)
            {
                innerListChanged = false;

                indexerForPrimaryKeys = new Dictionary<string, int>();

                for (int i = 0, count = this.List.Count; i < count; i++)
                {
                    UserInfo userInfo = this.List[i] as UserInfo;

                    indexerForPrimaryKeys.Add(string.Concat(userInfo.Id.ToString()), i);
                }
            }

            int index;

            if (indexerForPrimaryKeys.TryGetValue(string.Concat(id.ToString()), out index))
            {
                return this.List[index] as UserInfo;
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

        public UserCollection Pagination(int pageIndex, int pageSize)
        {
            if (InnerList.Count == 0)
                return null;

            int start = pageSize * (pageIndex - 1);
            int end = start + pageSize - 1;

            if (end > InnerList.Count - 1)
                end = InnerList.Count - 1;

            UserCollection pages = new UserCollection();

            for (int i = start; i <= end; i++)
            {
                pages.Add(InnerList[i] as UserInfo);
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
                        return (x as UserInfo).Id.CompareTo((y as UserInfo).Id);
                    case ExpensesSortBy.IdOrderByDesc:
                        return (y as UserInfo).Id.CompareTo((x as UserInfo).Id);
                    default:
                        return ((UserInfo)x).Id.CompareTo(((UserInfo)y).Id);
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

            public ExpensesCollectionEnumerator(UserCollection mappings)
            {
                enumerator = ((IEnumerable)mappings).GetEnumerator();
            }

            public UserInfo Current
            {
                get
                {
                    return (UserInfo)enumerator.Current;
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