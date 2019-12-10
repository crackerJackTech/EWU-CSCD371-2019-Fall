using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void SetProperty<T>(ref T field, T value,
            [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<ShoppingListItem> ShoppingList { get; } = new ObservableCollection<ShoppingListItem>();

        private string _Item;
        public string Item
        {
            get => _Item;
            set => SetProperty(ref _Item, value, "Item");
        }

        private ShoppingListItem _SelectedListItem;
        public ShoppingListItem SelectedListItem
        {
            get => _SelectedListItem;
            set => SetProperty(ref _SelectedListItem, value);
        }

        public Command AddListItemCommand { get; }
        public Command RemoveListItemCommand { get; }
        public ICommand ChangeListItemNameCommand { get; }

        private bool CanExecute { get; set; }

        public MainWindowViewModel()
        {
            Item = "Shopping List Traversal Experience";
            AddListItemCommand = new Command(OnAddListItem);
            RemoveListItemCommand = new Command(OnRemoveListItem);
            ChangeListItemNameCommand = new Command(OnChangeListItem);

            ShoppingList.Add(new ShoppingListItem("Item1"));
            ShoppingList.Add(new ShoppingListItem("Item2"));

        }

        private void OnAddListItem()
        {
            ShoppingList.Add(new ShoppingListItem($"Item{ShoppingList.Count + 1}"));
            CanExecute = true;
            AddListItemCommand.InvokeCanExecuteChanged();
        }

        private void OnRemoveListItem()
        {
            if(!(SelectedListItem is null))
            {
                ShoppingList.Remove(SelectedListItem);
                CanExecute = true;
                RemoveListItemCommand.InvokeCanExecuteChanged();
            }

        }

        private void OnChangeListItem()
        {
            Item = SelectedListItem.ToString();
        }



    }
}
