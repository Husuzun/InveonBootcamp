using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.ISP
{
    public interface IAdminAccess
    {
        void DeleteContent();
        void ConfigureSettings();
        void RestoreData();
    }

    public interface IUserAccess
    {
        void CreateContent();
        void EditContent();
        void PublishContent();
    }

    public interface IManagerAccess
    {
        void ArchiveContent();
        void ViewReports();
        void ManageUsers();
    }
    public class UserAccess : IUserAccess
    {
        public void CreateContent() { }
        public void EditContent() { }
        public void PublishContent() { }
    }

    public class ManagerAccess : IManagerAccess, IUserAccess
    {
        public void CreateContent() { }
        public void EditContent() { }
        public void PublishContent() { }
        public void ArchiveContent() { }
        public void ViewReports() { }
        public void ManageUsers() { }
    }

    public class AdminAccess : IAdminAccess, IManagerAccess, IUserAccess
    {
        public void DeleteContent() { }
        public void ConfigureSettings() { }
        public void RestoreData() { }
        public void CreateContent() { }
        public void EditContent() { }
        public void PublishContent() { }
        public void ArchiveContent() { }
        public void ViewReports() { }
        public void ManageUsers() { }
    }
}
