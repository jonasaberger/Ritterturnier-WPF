using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RitterturnierWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Checkboxes
        public bool _waffeCheckBoxChecked = false;
        public bool _knappeCheckBoxchecked = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Checkbox-Logic
        private void WaffeCheckbox_Checked (object sender, RoutedEventArgs e)
        {
           Waffe_Label.IsEnabled = true;
           WaffeBezeichnung_Input.IsEnabled = true;
           WaffenArtComboBox.IsEnabled = true;
           _waffeCheckBoxChecked = true;
        }
        private void WaffeCheckbox_Unchecked (object sender, RoutedEventArgs e)
        {
           Waffe_Label.IsEnabled = false;
           WaffeBezeichnung_Input.IsEnabled = false;
           WaffenArtComboBox.IsEnabled = false;
           _waffeCheckBoxChecked = false;
        }

        private void KnappeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Knappe_Label.IsEnabled = true;
            KnappeName_Input.IsEnabled = true;
            Ausbildungsgrad_Label.IsEnabled = true;
            Ausbildungsgrad_Slider.IsEnabled = true;
            _knappeCheckBoxchecked = true;
        }
        private void KnappeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Knappe_Label.IsEnabled = false;
            KnappeName_Input.IsEnabled = false;
            Ausbildungsgrad_Label.IsEnabled = false;
            Ausbildungsgrad_Slider.IsEnabled = false;
            _knappeCheckBoxchecked = false;
        }
    
    
        
    
    }
}