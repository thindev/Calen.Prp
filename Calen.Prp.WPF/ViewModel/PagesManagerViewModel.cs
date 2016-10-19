using Calen.Prp.WPF.ViewModel.TimeManage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Calen.Prp.WPF.ViewModel
{
    public class PagesManagerViewModel
    {
        ObservableCollection<PageViewModel> _pageList = new ObservableCollection<PageViewModel>();

        public ObservableCollection<PageViewModel> PageList
        {
            get
            {
                return _pageList;
            }
        }

        public void LoadManagingPages()
        {
            PageViewModel startPage = new PageViewModel();
            startPage.Index = 0;
            startPage.Title = "开始";
            startPage.IconGeometry = PathGeometry.Parse(Resources.GeometryStrings.HomePageIconData);
            _pageList.Add(startPage);
            PageViewModel timeManagePage = new PageViewModel();
            timeManagePage.Index = 1;
            timeManagePage.Title = "时间管理";
            timeManagePage.Content = new TimeManageViewModel();
            timeManagePage.IconGeometry = PathGeometry.Parse(Resources.GeometryStrings.TimeManagePageIconData);
            PageList.Add(timeManagePage);
            PageViewModel knowledgeAndExperiencePage = new PageViewModel();
            knowledgeAndExperiencePage.Index = 2;
            knowledgeAndExperiencePage.Title = "知识管理";
            knowledgeAndExperiencePage.IconGeometry = PathGeometry.Parse(Resources.GeometryStrings.KnowledgeManagePageIconData);
            _pageList.Add(knowledgeAndExperiencePage);
            PageViewModel contactsManagePage = new PageViewModel();
            contactsManagePage.Index = 3;
            contactsManagePage.Title = "人脉管理";
            contactsManagePage.IconGeometry = PathGeometry.Parse(Resources.GeometryStrings.ContactsManagePageIconData);
            _pageList.Add(contactsManagePage);
            PageViewModel informationChannelsPage = new PageViewModel();
            informationChannelsPage.Index = 4;
            informationChannelsPage.Title = "资讯管理";
            informationChannelsPage.IconGeometry = PathGeometry.Parse(Resources.GeometryStrings.InformationManagePageIconData);
            _pageList.Add(informationChannelsPage);
            PageViewModel healthManagePage = new PageViewModel();
            healthManagePage.Index = 4;
            healthManagePage.Title = "健康管理";
            healthManagePage.IconGeometry = PathGeometry.Parse(Resources.GeometryStrings.HealthManagePageIconData);
            _pageList.Add(healthManagePage);
        }
    }
}
