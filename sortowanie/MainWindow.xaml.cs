using System.Windows;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Linq;

namespace sortowanie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string strPath;

        public MainWindow()
        {
            InitializeComponent();


        }
        //zmienne
        List<String> Lista = new List<String>(); // nasza lista
        int i, j, p, pmin, pmax = 0;//dane potrzebne przy sortowanie tzw zmienne pomocnicze
        int Irepeat = 1;//ilosc powtorzen




        private void NumberInput_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
            string text = NumberInput.Text;

            Debug.WriteLine(text);




        }
        private void btn_repeat_Click(object sender, RoutedEventArgs e)
        {

            Irepeat = 1;
            void NumberInput_previewtextinput(object sender, TextCompositionEventArgs e)
            {
                e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);// tylko liczby w NumberInput-  ilosc powtorzen
            }
            Irepeat = int.Parse(NumberInput.Text);
            Debug.WriteLine(Irepeat);
            repeat_value.Text = "" + Irepeat;
        }

        private void btn_load_Click(object sender, RoutedEventArgs e) // wybor liczb
        {
            Lista.Clear();
            myListbox.ItemsSource = "";
            TabControl_Main.IsEnabled = true;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                using (var streamReader = File.OpenText(openFileDialog.FileName))// czytanie z pliku
                {
                    var s = string.Empty;
                    while ((s = streamReader.ReadLine()) != null)
                        Lista.Add(s);  //sam nwm
                }
                myListbox.ItemsSource = Lista;

            }







            //Lista.ForEach(item => Debug.WriteLine(item)); //wypisane kazdego indexu listy
            /* Debug.WriteLine("===");
             Debug.WriteLine(Lista[1]); */ //sprawdzenie czy lista dobrze funkcjonuje


        }


        private void btn_start_Click(object sender, RoutedEventArgs e) //Sortowanie przez wstawianie
        {





            List<int> intList = new List<int>();
            for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
            {
                intList.Add(int.Parse(Lista[o]));

            }
            // intList.ForEach(item => Debug.WriteLine(item));//wypisanie listy zmienionej e string na int w konsoli

            Stopwatch stopwatch = new Stopwatch();//zegar

            stopwatch.Start();
            //sortowanie
            for (int l = 0; l < Irepeat; l++)
            {
                for (j = intList.Count - 2; j >= 0; j--)
                {

                    int x = intList[j];
                    i = j + 1;

                    while ((i < intList.Count) && (x > intList[i]))
                    {
                        intList[i - 1] = intList[i];
                        i++;
                    }
                    intList[i - 1] = x;

                }
                myListbox_Sort.ItemsSource = intList;
            }



            stopwatch.Stop();

            //System.Diagnostics.Debug.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds); - wypisanie czasu w konsoli
            TextBoxTime.Text = "" + stopwatch.ElapsedMilliseconds;


        }







        private void btn_bomb_1_Click(object sender, RoutedEventArgs e)  //Sortowanie bąbelkowe - wersja 1
        {

            List<int> intList = new List<int>();
            for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
            {
                intList.Add(int.Parse(Lista[o]));

            }
            Stopwatch stopwatch = new Stopwatch();//zegar

            stopwatch.Start();
            //sortowanie
            for (int l = 0; l < Irepeat; l++)
            {
                for (j = 0; j < intList.Count - 1; j++)
                    for (i = 0; i < intList.Count - 1; i++)
                        if (intList[i] > intList[i + 1])
                        {
                            //w c++ jest funkcja swap, ktora zamienia wartosci, jednakze tutaj uzyjemy tradycyjnej metody z a i b 
                            intList[i] = intList[i] + intList[i + 1];
                            intList[i + 1] = intList[i] - intList[i + 1];
                            intList[i] = intList[i] - intList[i + 1];

                        }
            }





            myListBox_Sort_bomb_1.ItemsSource = intList;
            stopwatch.Stop();


            TextBoxTime_Bomb_1.Text = "" + stopwatch.ElapsedMilliseconds;

        }



        private void btn_bomb_2_Click(object sender, RoutedEventArgs e) //Sortowanie bąbelkowe - wersja 2
        {
            {

                List<int> intList = new List<int>();
                for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
                {
                    intList.Add(int.Parse(Lista[o]));

                }
                Stopwatch stopwatch = new Stopwatch();//zegar

                stopwatch.Start();
                //sortowanie

                for (int l = 0; l < Irepeat; l++)
                {
                    for (j = intList.Count - 1; j > 0; j--)
                        for (i = 0; i < j; i++)
                            if (intList[i] > intList[i + 1])
                            {
                                //w c++ jest funkcja swap, ktora zamienia wartosci, jednakze tutaj uzyjemy tradycyjnej metody z a i b 
                                intList[i] = intList[i] + intList[i + 1];
                                intList[i + 1] = intList[i] - intList[i + 1];
                                intList[i] = intList[i] - intList[i + 1];

                            }
                }




                myListBox_Sort_bomb_2.ItemsSource = intList;
                stopwatch.Stop();


                TextBoxTime_Bomb_2.Text = "" + stopwatch.ElapsedMilliseconds;

            }
        }



        private void btn_bomb_3_Click(object sender, RoutedEventArgs e) //Sortowanie bąbelkowe - wersja 3
        {
            {
                {

                    List<int> intList = new List<int>();
                    for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
                    {
                        intList.Add(int.Parse(Lista[o]));

                    }
                    Stopwatch stopwatch = new Stopwatch();//zegar

                    stopwatch.Start();
                    //sortowanie

                    for (int l = 0; l < Irepeat; l++)
                    {
                        for (j = intList.Count - 1; j > 0; j--)
                        {
                            p = 1;
                            for (i = 0; i < j; i++)
                                if (intList[i] > intList[i + 1])
                                {
                                    int t = intList[i];
                                    intList[i] = intList[i + 1];
                                    intList[i + 1] = t;

                                    p = 0;
                                }
                            if (p == 1) break;
                        }
                    }





                    myListBox_Sort_bomb_3.ItemsSource = intList;
                    stopwatch.Stop();


                    TextBoxTime_Bomb_3.Text = "" + stopwatch.ElapsedMilliseconds;

                }
            }
        }



        private void btn_bomb_4_Click(object sender, RoutedEventArgs e)//Sortowanie bąbelkowe - wersja 4- z błędem w postaci 1 pozycji(to co z Panem próbowałem rozwiązać na lekcji)
        {
            {
                {

                    List<int> intList = new List<int>();
                    for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
                    {
                        intList.Add(int.Parse(Lista[o]));

                    }
                    Stopwatch stopwatch = new Stopwatch();//zegar

                    stopwatch.Start();
                    //sortowanie
                    for (int l = 0; l < Irepeat; l++)
                    {
                        pmin = 0; pmax = intList.Count - 1;
                        do
                        {
                            p = -1;
                            for (i = pmin; i < pmax; i++)
                                if (intList[i] > intList[i + 1])
                                {
                                    int t = intList[i];
                                    intList[i] = intList[i + 1];
                                    intList[i + 1] = t;
                                    if (p < 0) pmin = i;
                                    p = i;
                                }
                            if (pmin > 1) pmin--;
                            pmax = p--;
                        } while (p >= 0);
                    }






                    myListBox_Sort_bomb_4.ItemsSource = intList;
                    stopwatch.Stop();


                    TextBoxTime_Bomb_4.Text = "" + stopwatch.ElapsedMilliseconds;

                }

            }
        }



        private void btn_bomb_5_Click(object sender, RoutedEventArgs e)//Sortowanie bąbelkowe - wersja 5
        {
            List<int> intList = new List<int>();
            for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
            {
                intList.Add(int.Parse(Lista[o]));

            }
            Stopwatch stopwatch = new Stopwatch();//zegar

            stopwatch.Start();
            //sortowanie
            for (int l = 0; l < Irepeat; l++)
            {
                pmin = 0; pmax = intList.Count - 2;
                do
                {
                    p = -1;
                    for (i = pmin; i <= pmax; i++)
                        if (intList[i] > intList[i + 1])
                        {
                            intList[i] = intList[i] + intList[i + 1];
                            intList[i + 1] = intList[i] - intList[i + 1];
                            intList[i] = intList[i] - intList[i + 1];
                            p = i;
                        }
                    if (p < 0) break;
                    pmax = p - 1;
                    p = -1;
                    for (i = pmax; i >= pmin; i--)
                        if (intList[i] > intList[i + 1])
                        {
                            intList[i] = intList[i] + intList[i + 1];
                            intList[i + 1] = intList[i] - intList[i + 1];
                            intList[i] = intList[i] - intList[i + 1];
                            p = i;
                        }
                    pmin = p + 1;
                } while (p >= 0);
            }






            myListBox_Sort_bomb_5.ItemsSource = intList;
            stopwatch.Stop();


            TextBoxTime_Bomb_5.Text = "" + stopwatch.ElapsedMilliseconds;
        }

        private void btn_headsort_Click(object sender, RoutedEventArgs e) //Sortowanie przez kopcowanie
        {
            List<int> intList = new List<int>();
            for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
            {
                intList.Add(int.Parse(Lista[o]));

            }
            //do tego przykladu zmienimy nasza liste na tablice
            int[] intTable = intList.ToArray();


            Stopwatch stopwatch = new Stopwatch();//zegar
            stopwatch.Start();
            //sortowanie

            static void heapSort(int[] arr, int n)
            {
                for (int i = n / 2 - 1; i >= 0; i--)
                    heapify(arr, n, i);
                for (int i = n - 1; i >= 0; i--)
                {
                    int temp = arr[0];
                    arr[0] = arr[i];
                    arr[i] = temp;
                    heapify(arr, i, 0);
                }
            }
            static void heapify(int[] arr, int n, int i)
            {
                int largest = i;
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                if (left < n && arr[left] > arr[largest])
                    largest = left;
                if (right < n && arr[right] > arr[largest])
                    largest = right;
                if (largest != i)
                {
                    int swap = arr[i];
                    arr[i] = arr[largest];
                    arr[largest] = swap;
                    heapify(arr, n, largest);
                }
            }
            for (int l = 0; l < Irepeat; l++)
            {
                heapSort(intTable, intList.Count);
            }





            myListBox_headsort.ItemsSource = intTable;
            stopwatch.Stop();


            TextBoxTimeHeadsort.Text = "" + stopwatch.ElapsedMilliseconds;

        }

        private void btn_select_Click(object sender, RoutedEventArgs e)// sortowanie szybkie
        {
            List<int> intList = new List<int>();
            for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
            {
                intList.Add(int.Parse(Lista[o]));

            }
            //do tego przykladu zmienimy nasza liste na tablice
            int[] intTable = intList.ToArray();

            Stopwatch stopwatch = new Stopwatch();//zegar


            //sortowanie
            void Sortuj_szybko(int lewy, int prawy)
            {
                int i;
                int j;
                int piwot;

                i = (lewy + prawy) / 2;
                piwot = intTable[i];
                intTable[i] = intTable[prawy];
                for (j = i = lewy; i < prawy; i++)
                {
                    if (intTable[i] < piwot)
                    {
                        //swap(intTable[i], intTable[j]);
                        intTable[i] = intTable[i] + intTable[j];
                        intTable[j] = intTable[i] - intTable[j];
                        intTable[i] = intTable[i] - intTable[j];
                        j++;
                    }
                }
                intTable[prawy] = intTable[j];
                intTable[j] = piwot;
                if (lewy < j - 1)
                {
                    Sortuj_szybko(lewy, j - 1);
                }
                if (j + 1 < prawy)
                {
                    Sortuj_szybko(j + 1, prawy);
                }
            }




            stopwatch.Start();






            Sortuj_szybko(0, intList.Count - 1);




            myListBox_Fast.ItemsSource = intList;
            stopwatch.Stop();


            TextTimeBoxFast.Text = "" + stopwatch.ElapsedMilliseconds;
        }

        private void btn_scalenie_Click(object sender, RoutedEventArgs e) //sortowanie scalenie
        {

            List<int> intList = new List<int>();

            for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
            {
                intList.Add(int.Parse(Lista[o]));

            }

            Stopwatch stopwatch = new Stopwatch();//zegar

            stopwatch.Start();
            //sortowanie
            void MergeSort(int i_p, int i_k)
            {
                int i_s, i1, i2, i;
                int N = intList.Count;
                int[] p = new int[N];
                i_s = (i_p + i_k + 1) / 2;
                if (i_s - i_p > 1) MergeSort(i_p, i_s - 1);
                if (i_k - i_s > 0) MergeSort(i_s, i_k);
                i1 = i_p; i2 = i_s;
                for (i = i_p; i <= i_k; i++)
                    p[i] = ((i1 == i_s) || ((i2 <= i_k) && (intList[i1] > intList[i2]))) ? intList[i2++] : intList[i1++];
                for (i = i_p; i <= i_k; i++) intList[i] = p[i];
            }



            for (int l = 0; l < Irepeat; l++)
            {
                MergeSort(0, Lista.Count - 1);
            }



            myListBox_scalenie.ItemsSource = intList;
            stopwatch.Stop();



            TextBoxTimeScalenie.Text = "" + stopwatch.ElapsedMilliseconds;
        }
        private void btn_wlasne_Click(object sender, RoutedEventArgs e)
        {
            List<int> intList = new List<int>();

            for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
            {
                intList.Add(int.Parse(Lista[o]));

            }

            Stopwatch stopwatch = new Stopwatch();//zegar

            stopwatch.Start();
            //sortowanie
            for (int l = 0; l < Irepeat; l++)
            {
                intList.Sort();
            }



            myListBox_wlasne.ItemsSource = intList;
            stopwatch.Stop();



            TextBox_time_wlasne.Text = "" + stopwatch.ElapsedMilliseconds;
        }
    }

}
