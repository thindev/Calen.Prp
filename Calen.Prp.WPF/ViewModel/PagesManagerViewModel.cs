using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _pageList.Add(startPage);
            PageViewModel timeManagePage = new PageViewModel();
            timeManagePage.Index = 1;
            timeManagePage.Title = "时间管理";
            PageList.Add(timeManagePage);
            PageViewModel knowledgeAndExperiencePage = new PageViewModel();
            knowledgeAndExperiencePage.Index = 2;
            knowledgeAndExperiencePage.Title = "知识与经验";
            _pageList.Add(knowledgeAndExperiencePage);
            PageViewModel contactsManagePage = new PageViewModel();
            contactsManagePage.Index = 3;
            contactsManagePage.Title = "交际圈";
            _pageList.Add(contactsManagePage);
            PageViewModel informationChannelsPage = new PageViewModel();
            informationChannelsPage.Index = 4;
            informationChannelsPage.Title = "资讯信息";
            _pageList.Add(informationChannelsPage);
            PageViewModel healthManagePage = new PageViewModel();
            healthManagePage.Index = 4;
            healthManagePage.Title = "健康管理";
            _pageList.Add(healthManagePage);
        }
    }
}
