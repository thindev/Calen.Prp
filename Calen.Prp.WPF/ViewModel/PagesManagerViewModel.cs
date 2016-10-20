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
            //PageViewModel startPage = new PageViewModel();
            //startPage.Index = 0;
            //startPage.Title = "开始";
            //startPage.Content = "start";
            //startPage.IconGeometry = PathGeometry.Parse(Resources.GeometryStrings.HomePageIconData);
            //_pageList.Add(startPage);
            PageViewModel timeManagePage = new PageViewModel();
            timeManagePage.Index = 1;
            timeManagePage.Title = "时间管理";
            TimeManageViewModel tm= new TimeManageViewModel() { IsToDoListMenuSelected = true };
            timeManagePage.Content = tm;
            tm.Activities.Add(new ActivityViewModel() { Name = "学习" });
            tm.Activities.Add(new ActivityViewModel() { Name = "工作" });
            tm.Activities.Add(new ActivityViewModel() { Name = "生活" });
            timeManagePage.IconGeometry = AppResourcesManager.GetResource<Geometry>("TimeManagePageIconData");
            PageList.Add(timeManagePage);
            
            PageViewModel knowledgeAndExperiencePage = new PageViewModel();
            knowledgeAndExperiencePage.Index = 2;
            knowledgeAndExperiencePage.Title = "知识管理";
            knowledgeAndExperiencePage.IconGeometry = AppResourcesManager.GetResource<Geometry>("KnowledgeManagePageIconData");
            _pageList.Add(knowledgeAndExperiencePage);

            PageViewModel informationChannelsPage = new PageViewModel();
            informationChannelsPage.Index = 4;
            informationChannelsPage.Title = "资讯管理";
            informationChannelsPage.IconGeometry = AppResourcesManager.GetResource<Geometry>("InformationManagePageIconData");
            _pageList.Add(informationChannelsPage);

            PageViewModel contactsManagePage = new PageViewModel();
            contactsManagePage.Index = 3;
            contactsManagePage.Title = "人脉管理";
            contactsManagePage.IconGeometry = AppResourcesManager.GetResource<Geometry>("ContactsManagePageIconData");
            _pageList.Add(contactsManagePage);
            
            PageViewModel healthManagePage = new PageViewModel();
            healthManagePage.Index = 4;
            healthManagePage.Title = "健康管理";
            healthManagePage.IconGeometry = AppResourcesManager.GetResource<Geometry>("HealthManagePageIconData");
            _pageList.Add(healthManagePage);

            PageViewModel lifeServicesManagePage = new PageViewModel();
            lifeServicesManagePage.Index = 4;
            lifeServicesManagePage.Title = "生活服务";
            lifeServicesManagePage.IconGeometry = AppResourcesManager.GetResource<Geometry>("LifeServiceManagePageIconData");
            _pageList.Add(lifeServicesManagePage);
        }
    }
}
