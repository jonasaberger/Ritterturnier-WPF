﻿using System.CodeDom;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using RitterturnierKonsole;


namespace RitterturnierWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Backend-Properties
        private Ritterturnier _ritterturnier;
        private FileManager _filemanager;
        private string _ritterName;
        private string _ritterTelef;
        private string _ritterRufname;

        private string _knappeName;
        private string _knappeTelef;
        private int _knappeAusbildungsgrad;

        private string _waffeBezeichnung;
        private WaffenArt _waffenArt;

        private int _idOffset = 0;
        

        // Checkboxes
        private bool _waffeCheckBoxChecked = false;
        private bool _knappeCheckBoxchecked = false;

        public MainWindow()
        {

            InitializeComponent();
            _ritterturnier = new Ritterturnier(new Teilnehmerliste());
            _filemanager = new FileManager("../../../saves/ritterturnier-save.json");

            // Initialize WaffeComboBox
            WaffenArtComboBox.Items.Add("Schwert");
            WaffenArtComboBox.Items.Add("Lanze");
            WaffenArtComboBox.Items.Add("Keule");

            // Initialize Statusbar
            Statusbar.Content = "Keine Statusmeldungen vorhanden.";
        }

        // Checkbox-Logic
        private void WaffeCheckbox_Checked (object sender, RoutedEventArgs e)
        {
            // Labels
            Waffe_Label.IsEnabled = true;
            WaffeBezeichnung_Label.IsEnabled = true;
            WaffenArt_Label.IsEnabled = true;

            // Inputs
            WaffeBezeichnung_Input.IsEnabled = true;
            WaffenArtComboBox.IsEnabled = true;

            _waffeCheckBoxChecked = true;
        }
        private void WaffeCheckbox_Unchecked (object sender, RoutedEventArgs e)
        {
            // Labels
            Waffe_Label.IsEnabled = false;
            WaffeBezeichnung_Label.IsEnabled= false;
            WaffenArt_Label.IsEnabled = false;

            // Inputs
            WaffeBezeichnung_Input.IsEnabled = false;
            WaffenArtComboBox.IsEnabled = false;

            _waffeCheckBoxChecked = false;
        }

        private void KnappeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Labels
            Knappe_Label.IsEnabled = true;
            Ausbildungsgrad_Label.IsEnabled = true;
            KnappeName_Label.IsEnabled = true;
            KnappeTelef_Label.IsEnabled = true;

            // Inputs
            KnappeName_Input.IsEnabled = true;
            Ausbildungsgrad_Slider.IsEnabled = true;
            KnappeTelef_Input.IsEnabled = true;

            _knappeCheckBoxchecked = true;
        }
        private void KnappeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Labels
            Knappe_Label.IsEnabled = false;
            Ausbildungsgrad_Label.IsEnabled = false;
            KnappeName_Label.IsEnabled = false;
            KnappeTelef_Label.IsEnabled = false;

            // Inputs
            KnappeName_Input.IsEnabled = false;
            Ausbildungsgrad_Slider.IsEnabled = false;
            KnappeTelef_Input.IsEnabled= false;

            _knappeCheckBoxchecked = false;
        }


        private void Ritter_Erstellen(object sender, RoutedEventArgs e)
        {
            // Überprüfen ob alle Felder gültig sind
            try
            {
                ValidateInputs();

                // Erstellen des Ritters & Überprüfen ob Ritter schon vorhanden
                try
                {
                    Ritter ritter = new Ritter(_ritterName, _ritterTelef, _ritterRufname);
                    if (_waffeCheckBoxChecked) { ritter.AddWaffe(new Waffe(_waffeBezeichnung, _waffenArt)); }
                    if(_knappeCheckBoxchecked) { ritter.AddKnappe(new Knappe(_knappeName, _knappeTelef, _knappeAusbildungsgrad)); }
     
                    NameSchonVorhandenException exception = _ritterturnier.Teilnehmerliste.AddTeilnehmer(ritter);
                    ritter.CorrectID(_idOffset);
                    // Erfolgreiche Erstellung eines Ritters
                    if (exception == null)
                    {
                        StatusSuccess("Erstellung Erfolgreich!");


                        // Liste aktualisieren
                        Main_Output.Text = _ritterturnier.Teilnehmerliste.ListeAlleTeilnehmer();
                    }
                    else {
                        throw exception; 
                    }
                }
                catch(NameSchonVorhandenException ex)
                {
                    _idOffset++;
                    StatusError(ex.Message);
                }
            }
            catch(UngueltigesInputException ex)
            {
                StatusError(ex.Message);
            }
        }

        private void StatusError(string message)
        {
            Statusbar.Foreground = new SolidColorBrush(Colors.White);
            Statusbar.Background = new SolidColorBrush(Colors.Red);
            Statusbar.Content = message;
        }

        private void StatusSuccess(string message) 
        {
            Statusbar.Foreground = new SolidColorBrush(Colors.White);
            Statusbar.Background = new SolidColorBrush(Colors.Green);
            Statusbar.Content = message;
        }

        private bool TelefValidate(string telefonnummer)
        {
            Regex telefonRegex = new Regex("\\(?\\+[0-9]{1,3}\\)? ?-?[0-9]{1,3} ?-?[0-9]{3,5} ?-?[0-9]{4}( ?-?[0-9]{3})? ?(\\w{1,10}\\s?\\d{1,6})?");
            return telefonRegex.IsMatch(telefonnummer);
        }

        private void ValidateInputs()
        {
            // Ritter
            if(Name_Input.Text != "")
            {
                _ritterName = Name_Input.Text;
            }
            else
            {
                throw new UngueltigesInputException("Ritter-Name");
            }
            if(Telef_Input.Text != "")
            {
                if(TelefValidate(Telef_Input.Text))
                {
                    _ritterTelef = Telef_Input.Text;
                }
                else
                {
                    throw new UngueltigesInputException("Telefon-Syntax");
                }
                
            }
            else
            {
                throw new UngueltigesInputException("Ritter-Telefonnummer");
            }
            if(Rufname_Input.Text != "")
            {
                _ritterRufname = Rufname_Input.Text;
            }
            else
            {
                throw new UngueltigesInputException("Ritter-Rufname");
            }

            
            // Waffe
            if (_waffeCheckBoxChecked)
            {
                if(WaffeBezeichnung_Input.Text != "")
                {
                    _waffeBezeichnung = WaffeBezeichnung_Input.Text;
                    
                    // WaffenArt
                    switch(WaffenArtComboBox.SelectedIndex)
                    {
                        case 0: _waffenArt = WaffenArt.S; break;
                        case 1: _waffenArt = WaffenArt.L; break;
                        case 2: _waffenArt = WaffenArt.K; break;
                        default: _waffenArt = WaffenArt.S; break;
                    }
                }
                else
                {
                    throw new UngueltigesInputException("Waffe-Bezeichnung");
                }
            }
            // Knappe
            if (_knappeCheckBoxchecked)
            {
                if(KnappeName_Input.Text != "")
                {
                    _knappeName = KnappeName_Input.Text;
                }
                else
                {
                    throw new UngueltigesInputException("Knappe-Name");
                }
                if(KnappeTelef_Input.Text != "")
                {
                    _knappeTelef = KnappeTelef_Input.Text;
                }
                else
                {
                    throw new UngueltigesInputException("Knappe-Telefonnummer");
                }
                _knappeAusbildungsgrad = Convert.ToInt32(Ausbildungsgrad_Slider.Value);
            }

        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _filemanager.ToFile(_ritterturnier.Teilnehmerliste);
                StatusSuccess("Speichern Erfolgreich!");
            }
            catch (Exception ex)
            {
                StatusError("Fehler beim Speichern!");
            }
            
        }

        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ritterturnier.Teilnehmerliste = _filemanager.FromFile();
                
                StatusSuccess($"Laden Erfolgreich - {_ritterturnier.Teilnehmerliste.TeilnehmerlisteList.Count} Teilnehmer geladen!");
                Main_Output.Text = _ritterturnier.Teilnehmerliste.ListeAlleTeilnehmer();
            }
            catch (Exception ex)
            {
                StatusError("Fehler beim Laden!");
            }
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            _filemanager.ToFile(new Teilnehmerliste());
            _ritterturnier = new Ritterturnier(new Teilnehmerliste());
            Main_Output.Text = "";
            StatusSuccess("DB + Lokales Output gecleared!");
        }

        private void ClearLocal_Button_Click(object sender, RoutedEventArgs e)
        {
            _ritterturnier = new Ritterturnier(new Teilnehmerliste());
            Main_Output.Text = "";
            StatusSuccess("Lokales Output gecleared");
        }
    }
}