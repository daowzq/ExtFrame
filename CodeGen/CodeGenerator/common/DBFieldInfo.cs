using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenerator.Common
{
    public class DBFieldInfo
    {
        private string _Column_Name;
        private string _Column_Default;
        private bool _Is_Nullable;
        private int _Character_Maximum_Length;
        private int _Numeric_Precision;
        private int _Numeric_Scale;
        private string _Data_Type;
        private bool _Is_Primary_Key;
        private DBForeignKeyInfo _DbForeignKeyInfo;
        private bool _EnableValidationAttributes;
        public string Column_Name
        {
            get
            {
                return this._Column_Name;
            }
        }
        public string Column_Default
        {
            get
            {
                return this._Column_Default;
            }
        }
        public bool Is_Nullable
        {
            get
            {
                return this._Is_Nullable;
            }
        }
        public int Character_Maximum_Length
        {
            get
            {
                return this._Character_Maximum_Length;
            }
        }
        public int Numeric_Precision
        {
            get
            {
                return this._Numeric_Precision;
            }
        }
        public int Numeric_Scale
        {
            get
            {
                return this._Numeric_Scale;
            }
        }
        public string Data_Type
        {
            get
            {
                return this._Data_Type;
            }
            set
            {
                this._Data_Type = value.ToLowerInvariant();
            }
        }
        public DBForeignKeyInfo ForeignKeyInfo
        {
            get
            {
                return this._DbForeignKeyInfo;
            }
            set
            {
                this._DbForeignKeyInfo = value;
            }
        }
        public bool Is_Primary_Key
        {
            get
            {
                return this._Is_Primary_Key;
            }
            set
            {
                this._Is_Primary_Key = value;
            }
        }
        public bool EnableValidationAttributes
        {
            get
            {
                return this._EnableValidationAttributes;
            }
            set
            {
                this._EnableValidationAttributes = value;
            }
        }
        public DBFieldInfo(string p_Column_Name, string p_Column_Default, bool p_Is_Nullable, int p_Character_Maximum_Length, int p_Numeric_Precision, int p_Numeric_Scale, string p_Data_Type)
        {
            this._Column_Name = p_Column_Name;
            this._Column_Default = p_Column_Default;
            this._Is_Nullable = p_Is_Nullable;
            this._Character_Maximum_Length = p_Character_Maximum_Length;
            this._Numeric_Precision = p_Numeric_Precision;
            this._Numeric_Scale = p_Numeric_Scale;
            this._Data_Type = p_Data_Type;
        }
        public bool IsPrimaryKey()
        {
            return this._Is_Primary_Key;
        }
        public bool IsForeignKey()
        {
            return this._DbForeignKeyInfo != null;
        }
        public string GetPropertyName()
        {
            string result;
            if (this.IsForeignKey())
            {
                if (this.Column_Name.EndsWith("_ID"))
                {
                    result = this.Column_Name.Substring(0, this.Column_Name.Length - 3);
                }
                else
                {
                    if (this.Column_Name.EndsWith("ID"))
                    {
                        result = this.Column_Name.Substring(0, this.Column_Name.Length - 2);
                    }
                    else
                    {
                        result = this.Column_Name;
                    }
                }
            }
            else
            {
                result = this.Column_Name;
            }
            return result;
        }
        public string GetPrivateVariableName()
        {
            string text;
            if (this.IsPrimaryKey())
            {
                text = "_" + this.Column_Name.ToLowerInvariant();
            }
            else
            {
                if (this.IsForeignKey())
                {
                    text = "_" + this.Column_Name.Substring(0, 1).ToLowerInvariant() + this.Column_Name.Substring(1);
                    if (text.EndsWith("_ID"))
                    {
                        text = text.Substring(0, text.Length - 3);
                    }
                    else
                    {
                        if (text.EndsWith("ID"))
                        {
                            text = text.Substring(0, text.Length - 2);
                        }
                    }
                }
                else
                {
                    text = "_" + this.Column_Name.Substring(0, 1).ToLowerInvariant() + this.Column_Name.Substring(1);
                }
            }
            return text;
        }
        public string GetSqlType()
        {
            string result;
            if (this.Data_Type.Equals("bigint") || this.Data_Type.Equals("int") || this.Data_Type.Equals("smallint") || this.Data_Type.Equals("tinyint") || this.Data_Type.Equals("bit") || this.Data_Type.Equals("datetime") || this.Data_Type.Equals("smalldatetime") || this.Data_Type.Equals("money") || this.Data_Type.Equals("smallmoney") || this.Data_Type.Equals("float") || this.Data_Type.Equals("real") || this.Data_Type.Equals("ntext") || this.Data_Type.Equals("text") || this.Data_Type.Equals("image") || this.Data_Type.Equals("uniqueidentifier"))
            {
                result = this.Data_Type;
            }
            else
            {
                if (this.Data_Type.Equals("char") || this.Data_Type.Equals("varchar") || this.Data_Type.Equals("nchar") || this.Data_Type.Equals("nvarchar") || this.Data_Type.Equals("binary") || this.Data_Type.Equals("varbinary"))
                {
                    result = string.Format("{0}({1})", this.Data_Type, this.Character_Maximum_Length);
                }
                else
                {
                    if (!this.Data_Type.Equals("decimal") && !this.Data_Type.Equals("numeric"))
                    {
                        throw new Exception("Unexpected data type: " + this.Data_Type);
                    }
                    result = string.Format("{0}({1},{2})", this.Data_Type, this.Numeric_Scale, this.Numeric_Precision);
                }
            }
            return result;
        }
        public string GetNetType()
        {
            string result;
            if (this.IsForeignKey())
            {
                result = DBTableInfo.GetSingularName(this._DbForeignKeyInfo.PK_Table);
            }
            else
            {
                string data_Type = this.Data_Type;
                string str = this.Is_Nullable ? "?" : "";
                if (data_Type.Equals("bigint"))
                {
                    result = "long" + str;
                }
                else
                {
                    if (data_Type.Equals("int"))
                    {
                        result = "int" + str;
                    }
                    else
                    {
                        if (data_Type.Equals("smallint"))
                        {
                            result = "short" + str;
                        }
                        else
                        {
                            if (data_Type.Equals("tinyint"))
                            {
                                result = "byte" + str;
                            }
                            else
                            {
                                if (data_Type.Equals("bit"))
                                {
                                    result = "bool" + str;
                                }
                                else
                                {
                                    if (data_Type.Equals("decimal"))
                                    {
                                        result = "System.Decimal" + str;
                                    }
                                    else
                                    {
                                        if (data_Type.Equals("numeric"))
                                        {
                                            result = "System.Decimal" + str;
                                        }
                                        else
                                        {
                                            if (data_Type.Equals("money"))
                                            {
                                                result = "System.Decimal" + str;
                                            }
                                            else
                                            {
                                                if (data_Type.Equals("smallmoney"))
                                                {
                                                    result = "System.Decimal" + str;
                                                }
                                                else
                                                {
                                                    if (data_Type.Equals("float"))
                                                    {
                                                        result = "float" + str;
                                                    }
                                                    else
                                                    {
                                                        if (data_Type.Equals("real"))
                                                        {
                                                            result = "double" + str;
                                                        }
                                                        else
                                                        {
                                                            if (data_Type.Equals("datetime"))
                                                            {
                                                                result = "DateTime" + str;
                                                            }
                                                            else
                                                            {
                                                                if (data_Type.Equals("smalldatetime"))
                                                                {
                                                                    result = "DateTime" + str;
                                                                }
                                                                else
                                                                {
                                                                    if (data_Type.Equals("char"))
                                                                    {
                                                                        result = "string";
                                                                    }
                                                                    else
                                                                    {
                                                                        if (data_Type.Equals("varchar"))
                                                                        {
                                                                            result = "string";
                                                                        }
                                                                        else
                                                                        {
                                                                            if (data_Type.Equals("text"))
                                                                            {
                                                                                result = "string";
                                                                            }
                                                                            else
                                                                            {
                                                                                if (data_Type.Equals("nchar"))
                                                                                {
                                                                                    result = "string";
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (data_Type.Equals("nvarchar"))
                                                                                    {
                                                                                        result = "string";
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (data_Type.Equals("ntext"))
                                                                                        {
                                                                                            result = "string";
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (data_Type.Equals("binary"))
                                                                                            {
                                                                                                result = "byte[]";
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (data_Type.Equals("varbinary"))
                                                                                                {
                                                                                                    result = "byte[]";
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (data_Type.Equals("image"))
                                                                                                    {
                                                                                                        result = "byte[]";
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (!data_Type.Equals("uniqueidentifier"))
                                                                                                        {
                                                                                                            throw new Exception("Unexpected data type: " + this.Data_Type);
                                                                                                        }
                                                                                                        result = "byte[]";
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
        public string GetInEqualityTest()
        {
            string result;
            if (this.IsForeignKey())
            {
                result = string.Concat(new string[]
				{
					"(",
					this.GetPrivateVariableName(),
					" == null) || (value == null) || (value.",
					this._DbForeignKeyInfo.PK_Column,
					" != ",
					this.GetPrivateVariableName(),
					".",
					this._DbForeignKeyInfo.PK_Column,
					")"
				});
            }
            else
            {
                if (this.GetNetType().Equals("string") || this.GetNetType().Equals("datetime"))
                {
                    result = string.Concat(new string[]
					{
						"(",
						this.GetPrivateVariableName(),
						" == null) || (value == null) || (!value.Equals(",
						this.GetPrivateVariableName(),
						"))"
					});
                }
                else
                {
                    result = "value != " + this.GetPrivateVariableName();
                }
            }
            return result;
        }
        public string GetFieldAttribute()
        {
            string result;
            if (this.IsPrimaryKey())
            {
                result = "[PrimaryKey(\"" + this.Column_Name + "\", Generator = PrimaryKeyType.Custom, CustomGenerator = typeof(IDGenerator), Access = PropertyAccess.NosetterLowercaseUnderscore)]";
            }
            else
            {
                if (this.IsForeignKey())
                {
                    result = string.Concat(new string[]
					{
						"[BelongsTo(\"",
						this.Column_Name,
						"\", Type = typeof(",
						this.GetPropertyName(),
						"), Cascade = CascadeEnum.All, Access = PropertyAccess.NosetterCamelcaseUnderscore)]"
					});
                }
                else
                {
                    string text = "[Property(\"" + this.Column_Name + "\", Access = PropertyAccess.NosetterCamelcaseUnderscore";
                    if (!this.Is_Nullable)
                    {
                        text += ", NotNull = true";
                    }
                    if (this.Data_Type.Equals("text") || this.Data_Type.Equals("ntext"))
                    {
                        text += ", ColumnType = \"StringClob\")]";
                    }
                    else
                    {
                        if (this.GetNetType().Equals("string") && this.Character_Maximum_Length > 1)
                        {
                            text = text + ", Length = " + this.Character_Maximum_Length.ToString() + ")";
                            if (this.EnableValidationAttributes)
                            {
                                text = text + ", ValidateLength(1, " + this.Character_Maximum_Length.ToString() + ")]";
                            }
                            else
                            {
                                text += "]";
                            }
                        }
                        else
                        {
                            text += ")]";
                        }
                    }
                    result = text;
                }
            }
            return result;
        }
        internal static string MakeLabel(string pPropName)
        {
            List<char> list = new List<char>();
            list.AddRange(pPropName.ToCharArray());
            bool flag = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (char.IsPunctuation(list[i]))
                {
                    list[i] = ' ';
                    flag = false;
                }
                else
                {
                    if (char.IsLower(list[i]))
                    {
                        flag = true;
                    }
                    else
                    {
                        if (flag && char.IsUpper(list[i]))
                        {
                            list.Insert(i, ' ');
                            flag = false;
                        }
                    }
                }
            }
            bool flag2 = true;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(list[i]))
                {
                    if (flag2)
                    {
                        list.RemoveAt(i);
                    }
                    flag2 = true;
                }
                else
                {
                    flag2 = false;
                }
            }
            return new string(list.ToArray());
        }
        public string GetLabel()
        {
            return DBFieldInfo.MakeLabel(this._Column_Name);
        }
        public override string ToString()
        {
            return this._Column_Name + " - " + this._Data_Type;
        }
    }
}
