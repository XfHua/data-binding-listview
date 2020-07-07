using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App304
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            AdsViewModel vm = new AdsViewModel();
            vm.getData();
            BindingContext = vm;

        }
    }

    public class AdsViewModel : INotifyPropertyChanged
    {

        private List<AdsViewModel> _modelDatas;
        public List<AdsViewModel> modelDatas
        {
            get { return _modelDatas; }
            set
            {
                _modelDatas = value;
                OnPropertyChanged("modelDatas");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }

        public AdsImg AdsImgModel { get; set; }
        public Ads AdsModel { get; set; }
            
        public AdsViewModel()
        {
        }

        public void getData() {

            AdsImg img = new AdsImg() {ImgPath = "imagePath"};
            Ads ads = new Ads() { Titel = "title",Description = "des" };

            modelDatas = new List<AdsViewModel>();

            modelDatas.Add( new AdsViewModel() { AdsImgModel = img, AdsModel = ads });
            modelDatas.Add(new AdsViewModel() { AdsImgModel = img, AdsModel = ads });
            modelDatas.Add(new AdsViewModel() { AdsImgModel = img, AdsModel = ads });

        }
    }

    public class Ads
    {
        public string Titel { get; set; }
        public string Description { get; set; }
        public List<AdsImg> AdsImg { get; set; }
    }

    public class AdsImg
    {
        public int Id { get; set; }
        public string ImgPath { get; set; }
        public int AdId { get; set; }
    }
}
