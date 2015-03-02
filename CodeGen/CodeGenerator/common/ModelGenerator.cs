using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using NVelocity;
using System.Diagnostics;
using Commons.Collections;
using NVelocity.App;

namespace CodeGenerator.Common
{
    public delegate void FileExists(string p_OutputDir, string p_FileName, ref FileHandlingResult fhResult);
    class ModelGenerator
    {
        private string _NameSpace;
        private bool _MakePartial;
        private bool _PropChange;
        private bool _EnableValidationAttributes;
        private FileHandlingResult _fhResult;
        private FileExists _FileExists;
        private VelocityEngine engine = null;
        public ModelGenerator(FileExists p_FileExists, string p_NameSpace, bool p_MakePartial, bool p_PropChange, bool p_Validate)
        {
            this._FileExists = p_FileExists;
            this._NameSpace = p_NameSpace;
            this._MakePartial = p_MakePartial;
            this._PropChange = p_PropChange;
            this._EnableValidationAttributes = p_Validate;
            this._fhResult = FileHandlingResult.None;
            this.engine = new VelocityEngine();
            ExtendedProperties extendedProperties = new ExtendedProperties();
            extendedProperties.AddProperty("file.resource.loader.path", new ArrayList(new string[]
			{
				".",
				".\\Templates"
			}));
            this.engine.Init(extendedProperties);
        }
        public FileHandlingResult GetFileHandlingResult()
        {
            return this._fhResult;
        }
        public void GenerateClass(string sTemplate, DBTableInfo p_Table, string p_OutputDir)
        {
            Template template = this.engine.GetTemplate(sTemplate, "GB2312");
            string className = p_Table.GetClassName();
            DBFieldInfo[] fields = p_Table.GetFields();
            DBRelatedTableInfo[] dbRelatedTableInfo = p_Table.GetDbRelatedTableInfo();
            for (int i = 0; i < fields.Length; i++)
            {
                fields[i].EnableValidationAttributes = this._EnableValidationAttributes;
            }
            Debug.WriteLine(string.Concat(new object[]
			{
				"Table: ",
				p_Table,
				" -> ",
				className
			}));
            VelocityContext velocityContext = new VelocityContext();
            velocityContext.Put("namespace", this._NameSpace);
            velocityContext.Put("developer", Environment.UserName);
            velocityContext.Put("Partial", this._MakePartial ? "partial" : "");
            velocityContext.Put("PropChange", this._PropChange);
            velocityContext.Put("table", p_Table);
            velocityContext.Put("fields", fields);
            velocityContext.Put("related", dbRelatedTableInfo);
            velocityContext.Put("date", DateTime.Now.ToString("yyyy-MM-dd"));
            string fileName = this.GetFileName(sTemplate, velocityContext);
            if (this.CanWriteThisFile(p_OutputDir, className, fileName))
            {
                StreamWriter streamWriter = new StreamWriter(p_OutputDir + fileName, false, Encoding.UTF8);
                try
                {
                    StringWriter stringWriter = new StringWriter();
                    template.Merge(velocityContext, stringWriter);
                    streamWriter.WriteLine(stringWriter.GetStringBuilder().ToString());
                }
                finally
                {
                    streamWriter.Close();
                }
            }
        }
        private string GetFileName(string sTemplate, VelocityContext context)
        {
            StreamReader streamReader = new StreamReader(".\\Templates\\" + sTemplate);
            string text = streamReader.ReadLine();
            if (text.StartsWith("##FILENAME:"))
            {
                text = text.Substring(11);
            }
            else
            {
                if (text.StartsWith("AimModel_with_IList"))
                {
                    text = "${table.GetClassName}_g.cs";
                }
                else
                {
                    text = "${table.GetClassName}.cs";
                }
            }
            StringReader reader = new StringReader(text);
            StringWriter stringWriter = new StringWriter();
            this.engine.Evaluate(context, stringWriter, null, reader);
            return stringWriter.GetStringBuilder().ToString();
        }
        private bool CanWriteThisFile(string p_OutputDir, string p_ClassName, string p_FileName)
        {
            bool result;
            if (File.Exists(p_OutputDir + p_FileName))
            {
                if ((this._fhResult & FileHandlingResult.All) == FileHandlingResult.None)
                {
                    this._FileExists(p_OutputDir, p_FileName, ref this._fhResult);
                }
                if ((this._fhResult & FileHandlingResult.Cancel) > FileHandlingResult.None)
                {
                    result = false;
                    return result;
                }
                if ((this._fhResult & FileHandlingResult.Skip) > FileHandlingResult.None)
                {
                    this.OneTimeFileRequestHandled();
                    result = false;
                    return result;
                }
                if ((this._fhResult & FileHandlingResult.Rename) > FileHandlingResult.None)
                {
                    int num = 0;
                    while (++num <= 999)
                    {
                        string str = string.Format(".{0:00#}", num);
                        if (!File.Exists(p_OutputDir + p_ClassName + str))
                        {
                            File.Move(p_OutputDir + p_FileName, p_OutputDir + p_ClassName + str);
                            this.OneTimeFileRequestHandled();
                            goto IL_10D;
                        }
                    }
                    throw new Exception("Unable to rename file!");
                }
                if ((this._fhResult & FileHandlingResult.OverWrite) > FileHandlingResult.None)
                {
                    this.OneTimeFileRequestHandled();
                }
            IL_10D: ;
            }
            result = true;
            return result;
        }
        private void OneTimeFileRequestHandled()
        {
            if ((this._fhResult & FileHandlingResult.All) == FileHandlingResult.None)
            {
                this._fhResult = FileHandlingResult.None;
            }
        }
    }


    [Flags]
    public enum FileHandlingResult
    {
        None = 0,
        OverWrite = 1,
        Rename = 2,
        Skip = 4,
        Cancel = 8,
        All = 16
    }
}
