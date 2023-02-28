using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiSelector.Model;
using System.Globalization;

namespace MauiSelector.ViewModel;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        DateTime dt = DateTime.Now.Date;

        // Inicializar seletores para seleção
        this.CreateDayList();
        this.GetPositionDay(dt.Day);

        this.CreateMonthList();
        this.GetPositionMonth(dt.Month);

        this.CreateYearList();
        this.GetPositionYear(dt.Year);
    }

    #region ** Criar variáveis para receber os parametros para o seletor **

    /* 
        Variável para exibir a data
    */
    [ObservableProperty]
    string displayLabelDate;

    /* 
        Seletor para lista de anos
    */
    [ObservableProperty]
    List<Selector> itemsYear;

    [ObservableProperty]
    int indexYear;

    [ObservableProperty]
    int year;

    [ObservableProperty]
    string textYear;

    /* 
        Seletor para lista de meses
    */
    [ObservableProperty]
    List<Selector> itemsMonth;

    [ObservableProperty]
    int indexMonth;

    [ObservableProperty]
    int month;

    [ObservableProperty]
    string textMonth;

    /* 
        Seletor para lista de dias
    */
    [ObservableProperty]
    List<Selector> itemsDay;

    [ObservableProperty]
    int indexDay;

    [ObservableProperty]
    int day;

    [ObservableProperty]
    string textDay;

    #endregion

    #region ** Metodo para criar listas de seletores **

    /* 
        Exibir data na tela
    */
    [RelayCommand] // Criar uma opção de comando para chamar no xaml
    void DisplayDate()
    {
        var _date = this.Year + "-" + this.Month + "-" + this.Day;
        // Verificar se é uma data válida
        if (!IsDate(_date))
            this.DisplayLabelDate = "data inválida";

        this.DisplayLabelDate = Convert.ToDateTime(_date).ToLongDateString();
    }

    /* 
        Criar lista de dias
    */
    public void CreateDayList()
    {
        this.ItemsDay = new List<Selector>();
        int _day = 0;

        for (int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Date.Year, DateTime.Now.Date.Month); i++)
        {
            _day++;
            this.ItemsDay.Add(new Selector
            {
                Id = _day,
                Description = _day.ToString()
            });
        }       
    }

    /* 
        Posicionar o dia no seletor
    */
    public void GetPositionDay(int day)
    {
        if (this.ItemsDay.Count > 0)
        {
            var _index = this.ItemsDay.FindIndex(x => x.Id == day);
            // Se for -1 é porque não encontrou, então fica na primeira posição do seletor
            this.IndexDay = _index == -1 ? 0 : _index;
            this.Day = this.ItemsDay[_index == -1 ? 0 : _index].Id;
            this.TextDay = this.ItemsDay[_index == -1 ? 0 : _index].Description;
        }
    }

    /* 
        Criar lista de meses
    */
    public void CreateMonthList()
    {
        this.ItemsMonth = new List<Selector>();
        
        // Recuperar idioma utlizado pelo dispositivo
        CultureInfo cultureInfo = new CultureInfo(CultureInfo.CurrentCulture.Name);
        int countSelector = 0;

        foreach (string nameMonth in cultureInfo.DateTimeFormat.MonthNames)
        {
            // Quando chegar no 12, é porque já adicionou o mês de dezembro
            if (countSelector == 12) break;

            // Adicionar o mês ao Selector
            this.ItemsMonth.Add(new Selector
            {
                Id = countSelector + 1,
                Description = nameMonth
            });

            countSelector++;
        }
    }

    /* 
        Posicionar o mês no seletor
    */
    public void GetPositionMonth(int month)
    {
        if (this.ItemsMonth.Count > 0)
        {
            var _index = this.ItemsMonth.FindIndex(x => x.Id == month);
            // Se for -1 é porque não encontrou, então fica na primeira posição do seletor
            this.IndexMonth = _index == -1 ? 0 : _index;
            this.Month = this.ItemsMonth[_index == -1 ? 0 : _index].Id;
            this.TextMonth = this.ItemsMonth[_index == -1 ? 0 : _index].Description;
        }
    }

    /* 
        Criar lista de anos
    */
    public void CreateYearList()
    {
        this.ItemsYear = new List<Selector>();
        Year years = new();
        for (int i = years.First; i <= years.Last; i++)
        {
            this.ItemsYear.Add(new Selector
            {
                Id = i,
                Description = i.ToString()
            });
        }
    }

    /* 
        Posicionar o ano no seletor
    */
    public void GetPositionYear(int year)
    {
        if (this.ItemsYear.Count > 0)
        {
            var _index = this.ItemsYear.FindIndex(x => x.Id == year);
            // Se for -1 é porque não encontrou, então fica na primeira posição do seletor
            this.IndexYear = _index == -1 ? 0 : _index;
            this.Year = this.ItemsYear[_index == -1 ? 0 : _index].Id;
            this.TextYear = this.ItemsYear[_index == -1 ? 0 : _index].Description;
        }
    }

    // Validate Date (método bônus)
    bool IsDate(string date)
    {
        if (string.IsNullOrWhiteSpace(date))
            return false;
        DateTime returnDate = DateTime.MinValue;
        return DateTime.TryParse(date, out returnDate) ? true : false;
    }

    #endregion
}
