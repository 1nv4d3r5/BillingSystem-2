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
    public sealed class CardCollection : CollectionBase
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
        public CardCollection() { }

        /// <summary>
        /// Constructor using CcZlCzBillInfo array.
        /// </summary>
        /// <param name="value" />
        public CardCollection(CardInfo[] value)
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
            sb.Append("<CardInfo>");
            for (int i = 0; i < this.Count; i++)
            {
                sb.Append(this[i].ToXmlTree());
            }
            sb.Append("</CardInfo>");
            return sb.ToString();
        }

        public string Serialize()
        {
            XmlSerializer s = new XmlSerializer(typeof(CardCollection));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static CardCollection DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(CardCollection));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as CardCollection;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public CardInfo this[int index]
        {
            get
            {
                return (CardInfo)this.List[index];
            }
        }

        public int Add(CardInfo value)
        {
            return this.List.Add(value);
        }

        public void AddRange(CardInfo[] value)
        {
            for (int i = 0; (i < value.Length); i++)
            {
                this.Add(value[i]);
            }
        }

        public void AddRange(CardCollection value)
        {
            for (int i = 0; (i < value.Count); i++)
            {
                this.Add(value.List[i] as CardInfo);
            }
        }

        public bool Contains(CardInfo value)
        {
            if (IndexOf(value) > -1)
                return true;

            return false;
        }

        public void CopyTo(CardInfo[] array, int index)
        {
            this.List.CopyTo(array, index);
        }

        public int IndexOf(CardInfo value)
        {
            for (int i = 0, count = this.List.Count; i < count; i++)
            {
                if (value.Equals(this.List[i] as CardInfo))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, CardInfo value)
        {
            List.Insert(index, value);

            innerListChanged = true;
        }

        public void Remove(CardInfo value)
        {
            List.Remove(value);

            innerListChanged = true;
        }

        public CardInfo Get(long id)
        {
            if (indexerForPrimaryKeys == null || innerListChanged)
            {
                innerListChanged = false;

                indexerForPrimaryKeys = new Dictionary<string, int>();

                for (int i = 0, count = this.List.Count; i < count; i++)
                {
                    CardInfo cardInfo = this.List[i] as CardInfo;

                    indexerForPrimaryKeys.Add(string.Concat(cardInfo.Id.ToString()), i);
                }
            }

            int index;

            if (indexerForPrimaryKeys.TryGetValue(string.Concat(id.ToString()), out index))
            {
                return this.List[index] as CardInfo;
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

        public CardCollection Pagination(int pageIndex, int pageSize)
        {
            if (InnerList.Count == 0)
                return null;

            int start = pageSize * (pageIndex - 1);
            int end = start + pageSize - 1;

            if (end > InnerList.Count - 1)
                end = InnerList.Count - 1;

            CardCollection pages = new CardCollection();

            for (int i = start; i <= end; i++)
            {
                pages.Add(InnerList[i] as CardInfo);
            }

            return pages;
        }

        public void Sort()
        {
            this.InnerList.Sort(new CardCollectionComparer());
        }

        public void Sort(int sortBy)
        {
            this.InnerList.Sort(new CardCollectionComparer(sortBy));
        }

        public void Sort(CardSortBy sortBy)
        {
            this.InnerList.Sort(new CardCollectionComparer(sortBy));
        }

        #endregion

        #region Enum CardSortBy

        public enum CardSortBy
        {
            IdOrderByAsc,
            IdOrderByDesc
        }

        #endregion

        #region Class CardCollectionComparer

        private sealed class CardCollectionComparer : IComparer
        {
            private CardSortBy sortBy;

            public CardCollectionComparer() { }

            public CardCollectionComparer(CardSortBy sortBy)
            {
                this.sortBy = sortBy;
            }

            public CardCollectionComparer(int sortBy)
            {
                this.sortBy = (CardSortBy)sortBy;
            }

            public int Compare(object x, object y)
            {
                switch (sortBy)
                {
                    case CardSortBy.IdOrderByAsc:
                        return (x as CardInfo).Id.CompareTo((y as CardInfo).Id);
                    case CardSortBy.IdOrderByDesc:
                        return (y as CardInfo).Id.CompareTo((x as CardInfo).Id);
                    default:
                        return ((CardInfo)x).Id.CompareTo(((CardInfo)y).Id);
                }
            }
        }

        #endregion

        #region Class CcZlCzBillCollectionEnumerator

        public new CardCollectionEnumerator GetEnumerator()
        {
            return new CardCollectionEnumerator(this);
        }

        public class CardCollectionEnumerator : IEnumerator
        {
            private IEnumerator enumerator;

            public CardCollectionEnumerator(CardCollection mappings)
            {
                enumerator = ((IEnumerable)mappings).GetEnumerator();
            }

            public CardInfo Current
            {
                get
                {
                    return (CardInfo)enumerator.Current;
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