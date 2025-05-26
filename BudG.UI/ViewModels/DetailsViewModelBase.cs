using BudG.UI.Events;
using BudG.UI.Interface;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudG.UI.ViewModels
{
    public abstract class DetailsViewModelBase : ViewModelBase, IDetailsViewModel
    {
        protected IEventAggregator _eventAggregator;
        private bool _haschanges;

        public DetailsViewModelBase(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            DeleteCommand = new DelegateCommand(OnDeleteCommand);
        }

        protected abstract void OnDeleteCommand();


        protected abstract bool OnSaveCanExecute();

        protected abstract void OnSaveExecute();
        

        public bool HasChanges
        {
            get { return _haschanges; }
            set
            {
                if (_haschanges != value)
                {
                    _haschanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }

            }
        }
        public virtual void RaiseDetailDeleteEvent(int modelId)
        {
            _eventAggregator.GetEvent<AfterDeletedEvent>().Publish
                (new AfterDeletedEventArgs
                {
                    Id = modelId,
                    
                    ViewModelName = this.GetType().Name
                });
        }
        public virtual void RaiseDetailSavedEvent (int modelId,string displayMember)
        {
            _eventAggregator.GetEvent<AfterSavedEvent>().Publish
                (new AfterSavedEventArgs
                {
                    Id = modelId,
                    DisplayMember = displayMember,
                    ViewModelName = this.GetType().Name
                });
        }
        public abstract Task LoadAsync(int? id);
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

    }
}
