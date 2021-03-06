﻿using Kmong_Simple_LoginPage.Infrastructure;
using Kmong_Simple_LoginPage.MessageDef;
using Kmong_Simple_LoginPage.Modal;
using Kmong_Simple_LoginPage.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Kmong_Simple_LoginPage.ViewModel
{
    public class PageOneViewModel : BindableBase
    {
        private readonly EventAggregator eventAggregator;

        private object _Modal;
        public object Modal
        {
            get { return _Modal; }
            set { SetProperty(ref _Modal, value); }
        }

        private ObservableCollection<ListViewItemModel> _listViewItemList;
        public ObservableCollection<ListViewItemModel> BListViewItemList
        {
            get { return _listViewItemList; }
            set { SetProperty(ref _listViewItemList, value); }
        }

        private ICommand _OpenModal;
        public ICommand COpenModal
        {
            get { return _OpenModal; }
            set { _OpenModal = value; }
        }

        public PageOneViewModel(EventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            COpenModal = new DelegateCommand<ListViewItemModel>(OnOpenModal);

            BListViewItemList = new ObservableCollection<ListViewItemModel>();
            BListViewItemList.Add( new ListViewItemModel("김밥", "라면", "햄", "김치"));
            BListViewItemList.Add( new ListViewItemModel("김밥2", "라면2", "햄2", "김치2"));
            BListViewItemList.Add( new ListViewItemModel("김밥3", "라면3", "햄3", "김치3"));
            BListViewItemList.Add( new ListViewItemModel("김밥4", "라면4", "햄4", "김치4"));

            eventAggregator.GetEvent<CloseModal>().Subscribe(() =>
            {
                Modal = null;
            });


            eventAggregator.GetEvent<ChangeMenuIntoGimbop>().Subscribe(() =>
            {
                BListViewItemList.Clear();
                BListViewItemList.Add( new ListViewItemModel("김밥", "라면", "햄", "김치"));
                BListViewItemList.Add( new ListViewItemModel("김밥2", "라면2", "햄2", "김치2"));
                BListViewItemList.Add( new ListViewItemModel("김밥3", "라면3", "햄3", "김치3"));
                BListViewItemList.Add( new ListViewItemModel("김밥4", "라면4", "햄4", "김치4"));
            });

            eventAggregator.GetEvent<ChangeMenuIntoNoodle>().Subscribe(() =>
            {
                BListViewItemList.Clear();
                BListViewItemList.Add( new ListViewItemModel("*김밥", "*라면", "*햄", "*김치"));
                BListViewItemList.Add( new ListViewItemModel("*김밥2", "*라면2", "*햄2", "*김치2"));
                BListViewItemList.Add( new ListViewItemModel("*김밥3", "*라면3", "*햄3", "*김치3"));
                BListViewItemList.Add( new ListViewItemModel("*김밥4", "*라면4", "*햄4", "*김치4"));
            });
        }

        public void OnOpenModal(ListViewItemModel model)
        {
            Modal = new ModalPage(eventAggregator, model);
        }

    }
}
