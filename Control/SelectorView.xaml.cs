using System.Windows.Input;
using MauiSelector.Model;

namespace MauiSelector.Control
{
    public partial class SelectorView : ContentView
    {
        #region ** Variáveis para receber os parametros **

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(SelectorView), string.Empty);

        public string Title
        {
            get => (string)GetValue(SelectorView.TitleProperty);
            set => SetValue(SelectorView.TitleProperty, value);
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(SelectorView), string.Empty);

        public string Text
        {
            get => (string)GetValue(SelectorView.TextProperty);
            set => SetValue(SelectorView.TextProperty, value);
        }

        public static readonly BindableProperty IdSelectorProperty = BindableProperty.Create(nameof(IdSelector), typeof(int), typeof(SelectorView), 0);

        public int IdSelector
        {
            get => (int)GetValue(SelectorView.IdSelectorProperty);
            set => SetValue(SelectorView.IdSelectorProperty, value);
        }

        public static readonly BindableProperty IndexSelectorProperty = BindableProperty.Create(nameof(IndexSelector), typeof(int), typeof(SelectorView), 0);

        public int IndexSelector
        {
            get => (int)GetValue(SelectorView.IndexSelectorProperty);
            set => SetValue(SelectorView.IndexSelectorProperty, value);
        }

        public static readonly BindableProperty IsVisibleTitleProperty = BindableProperty.Create(nameof(IsVisibleTitle), typeof(bool), typeof(SelectorView), false);

        public bool IsVisibleTitle
        {
            get => (bool)GetValue(SelectorView.IsVisibleTitleProperty);
            set => SetValue(SelectorView.IsVisibleTitleProperty, value);
        }

        public static readonly BindableProperty ItemsSelectorProperty = BindableProperty.Create(nameof(ItemsSelector), typeof(List<Selector>), typeof(SelectorView), null);

        public List<Selector> ItemsSelector
        {
            get => (List<Selector>)GetValue(SelectorView.ItemsSelectorProperty);
            set => SetValue(SelectorView.ItemsSelectorProperty, value);
        }

        #endregion

        #region ** Comandos para percorrer o seletor **

        // Procura pelos dados do Cep
        public ICommand GoToSelectorCommand => new Command(() => GoToSelector());
        public ICommand GoBackSelectorCommand => new Command(() => GoBackSelector());

        #endregion

        public SelectorView()
        {
            InitializeComponent();            
        }

        /* 
            Avançar posição no seletor
        */
        void GoToSelector()
        {
            if (this.ItemsSelector != null && this.ItemsSelector.Count > 0)
            {
                this.IndexSelector++;
                if (this.IndexSelector > this.ItemsSelector.Count - 1)
                    this.IndexSelector = 0;
                this.Text = this.ItemsSelector[this.IndexSelector].Description;
                this.IdSelector = this.ItemsSelector[this.IndexSelector].Id;
            }
        }

        /* 
            Recuar posição no seletor
        */
        void GoBackSelector()
        {
            if (this.ItemsSelector != null && this.ItemsSelector.Count > 0)
            {
                this.IndexSelector--;
                if (this.IndexSelector < 0)
                    this.IndexSelector = this.ItemsSelector.Count - 1;
                this.Text = this.ItemsSelector[this.IndexSelector].Description;
                this.IdSelector = this.ItemsSelector[this.IndexSelector].Id;
            }
        }
    }
}