using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace FBJHelper
{
   public sealed class FieldLoader:IDisposable
    {
       public bool _disposed;
       private IDataRecord datarecord;

       public FieldLoader(IDataRecord record)
       {
           this.datarecord = record;
       }

       protected void Dispose(bool disposing)
       {
           if (!_disposed)
           {
               if (disposing)
               {
               }
               _disposed = true;
           }
       }

       //~FieldLoader()
       //{
       //    Dispose(false);
       //}

       public void Dispose()
       {
           Dispose(true);
           GC.SuppressFinalize(this);
       }

       public bool IsDBNull(int i)
       {
           return this.datarecord.IsDBNull(i);
       }

       public bool IsDBNull(string name)
       {
           return this.datarecord.IsDBNull(this.datarecord.GetOrdinal(name));
       }

       public bool GetBoolean(string name)
       {
           bool boolean = false;
           if (!this.IsDBNull(name))
           {
               boolean = this.datarecord.GetBoolean(this.datarecord.GetOrdinal(name));
           }
           return boolean;
       }

       public byte GetByte(string name)
       {
           return this.datarecord.GetByte(this.datarecord.GetOrdinal(name ));
       }

       public long GetBytes(string name, long fieldoffset, byte[] buffer, int bufferoffset, int length)
       {
           return this.datarecord.GetBytes(this.datarecord.GetOrdinal(name),fieldoffset,buffer,bufferoffset,length);
       }

       public char GetChar(string name)
       {
           return this.datarecord.GetChar(this.datarecord.GetOrdinal(name));
       }

       public long GetChars(string name, long fieldoffset, char[] buffer, int bufferoffset, int length)
       {
           return this.datarecord.GetChars(this.datarecord.GetOrdinal(name), fieldoffset, buffer, bufferoffset, length);
       }

       //public IDataReader GetData(int i)
       //{
       //   return this.datarecord.GetData(i);
       //}

       //public string GetDataTypeName(int i)
       //{
       //    return this.datarecord.GetDataTypeName(i);
       //}

       public string GetDataTypeName(string name)
       {
           return this.datarecord.GetDataTypeName(this.datarecord.GetOrdinal(name));
       }

       public DateTime GetDateTime(string name)
       {
           if (this.IsDBNull(name))
           {
               return DateTime.Now;
           }
           return this.datarecord.GetDateTime(this.datarecord.GetOrdinal(name));
       }

       public decimal GetDecimal(string name)
       {
           decimal @decimal = 0M;
           if (!this.IsDBNull(name))
           {
               @decimal = this.datarecord.GetDecimal(this.datarecord.GetOrdinal(name));
           }
           return @decimal;
       }

       public double GetDouble(string name)
       {
           double num = 0.0;
           if (!this.IsDBNull(name))
           {
               num = this.datarecord.GetDouble(this.datarecord.GetOrdinal(name));
           }
           return num;
       }

       public Type GetFieldType(string name)
       {
           return this.datarecord.GetFieldType(this.datarecord.GetOrdinal(name));
       }

       public float GetFloat(string name)
       {
           float @float = 0f;
           if (!this.IsDBNull(name))
           {
               @float = this.datarecord.GetFloat(this.datarecord.GetOrdinal(name));
           }
           return @float;
       }

       public Guid GetGuid(string name)
       {
           return this.datarecord.GetGuid(this.datarecord.GetOrdinal(name));
       }

       public short GetInt16(string name)
       {
           if (this.IsDBNull(name))
           {
               return 0;
           }
           return this.datarecord.GetInt16(this.datarecord.GetOrdinal(name));
       }

       public int GetInt32(string name)
       {
           if (this.IsDBNull(name))
           {
               return 0;
           }
           return this.datarecord.GetInt32(this.datarecord.GetOrdinal(name));
       }

       public long GetInt64(string name)
       {
           if (this.IsDBNull(name))
           {
               return 0L;
           }
           return this.datarecord.GetInt64(this.datarecord.GetOrdinal(name));
       }

       public string GetString(string name)
       {
           string str = string.Empty;
           if (!this.IsDBNull(name))
           {
               str = this.datarecord.GetString(this.datarecord.GetOrdinal(name));
           }
           return str;
       }

       public object GetValue(string name)
       {
           return this.datarecord.GetValue(this.datarecord.GetOrdinal(name));
       }


       public void LoadBoolean(string name, ref bool field)
       {
           field = this.GetBoolean(name);
       }

       public void LoadByte(string name, ref byte field)
       {
           field = this.GetByte(name);
       }

       public void LoadBytes(string name, ref long field, long fieldOffset, byte[] buffer, int bufferOffset, int length)
       {
           field = this.GetBytes(name, fieldOffset, buffer, bufferOffset, length);
       }

       public void LoadChar(string name, ref char field)
       {
           field = this.GetChar(name);
       }

       public void LoadChars(string name, ref long field, long fieldOffset, char[] buffer, int bufferOffset, int length)
       {
           field = this.GetChars(name, fieldOffset, buffer, bufferOffset, length);
       }

       public void LoadDateTime(string name, ref DateTime field)
       {
           field = this.GetDateTime(name);
       }

       public void LoadDecimal(string name, ref decimal field)
       {
           field = this.GetDecimal(name);
       }

       public void LoadDouble(string name, ref double field)
       {
           field = this.GetDouble(name);
       }

       public void LoadFloat(string name, ref float field)
       {
           field = this.GetFloat(name);
       }

       public void LoadGuid(string name, ref Guid field)
       {
           field = this.GetGuid(name);
       }

       public void LoadInt16(string name, ref short field)
       {
           field = this.GetInt16(name);
       }

       public void LoadInt32(string name, ref int field)
       {
           field = GetInt32(name);
       }

       public void LoadInt32(string name, ref int field, int defaultValue)
       {
           if (GetInt32(name) == null)
           {
               field = defaultValue;
           }
           else
           {
               field = GetInt32(name);
           }
       }

       public void LoadInt64(string name, ref long field)
       {
           field = this.GetInt64(name);
       }

       public void LoadString(string name, ref string field)
       {
           field = this.GetString(name);
       }

    }
}
