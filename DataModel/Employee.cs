// 
// Generated by ActiveRecord Generator
// 
//
namespace DataModel
{
    using Castle.ActiveRecord;
    
    
    [ActiveRecord("Employee")]
    public class Employee : ActiveRecordBase
    {
        
        private string _iD;
        
        private string _name;
        
        private int _age;
        
        private string _job;
        
        private string _email;
        
        private string _postion;
        
        private System.DateTime _createTime;
        
        private string _createId;
        
        private string _createName;
        
        [PrimaryKey(PrimaryKeyType.Native)]
        public string ID
        {
            get
            {
                return this._iD;
            }
            set
            {
                this._iD = value;
            }
        }
        
        [Property()]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        
        [Property()]
        public int Age
        {
            get
            {
                return this._age;
            }
            set
            {
                this._age = value;
            }
        }
        
        [Property()]
        public string Job
        {
            get
            {
                return this._job;
            }
            set
            {
                this._job = value;
            }
        }
        
        [Property()]
        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }
        
        [Property()]
        public string Postion
        {
            get
            {
                return this._postion;
            }
            set
            {
                this._postion = value;
            }
        }
        
        [Property()]
        public System.DateTime CreateTime
        {
            get
            {
                return this._createTime;
            }
            set
            {
                this._createTime = value;
            }
        }
        
        [Property()]
        public string CreateId
        {
            get
            {
                return this._createId;
            }
            set
            {
                this._createId = value;
            }
        }
        
        [Property()]
        public string CreateName
        {
            get
            {
                return this._createName;
            }
            set
            {
                this._createName = value;
            }
        }
        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(Employee));
        }
        
        public static Employee[] FindAll()
        {
            return ((Employee[])(ActiveRecordBase.FindAll(typeof(Employee))));
        }
        
        public static Employee Find(string ID)
        {
            return ((Employee)(ActiveRecordBase.FindByPrimaryKey(typeof(Employee), ID)));
        }
    }
}
