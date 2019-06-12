//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Linq;

//namespace MoneySpending.Model
//{
//	[Serializable]
//    public class TwentyEightDaysCollection : INotifyPropertyChanged {

//        public List<DayExpences> TwentyEightDays { get; set; }

//        public List<OnePlanExpence> PlanList { get; set; }

//        #region Коллекции с суммами расходов за каждую неделю по статьям

//        private ObservableCollection<double> firstWeekSumCollection = new ObservableCollection<double>();
//        public ObservableCollection<double> FirstWeekSumCollection {
//            get {
//                firstWeekSumCollection = DoTheWeek_Number_Sums(1, firstWeekSumCollection);
//                return firstWeekSumCollection;
//            }
//        }

//        private ObservableCollection<double> secondWeekSumCollection = new ObservableCollection<double>();
//        public ObservableCollection<double> SecondWeekSumCollection {
//            get {
//                secondWeekSumCollection = DoTheWeek_Number_Sums(2, secondWeekSumCollection);
//                return secondWeekSumCollection;
//            }
//        }

//        private ObservableCollection<double> thirdWeekSumCollection = new ObservableCollection<double>();
//        public ObservableCollection<double> ThirdWeekSumCollection {
//            get {
//                thirdWeekSumCollection = DoTheWeek_Number_Sums(3, thirdWeekSumCollection);
//                return thirdWeekSumCollection;
//            }
//        }

//        private ObservableCollection<double> fourthWeekSumCollection = new ObservableCollection<double>();
//        public ObservableCollection<double> FourthWeekSumCollection {
//            get {
//                fourthWeekSumCollection = DoTheWeek_Number_Sums(4, fourthWeekSumCollection);
//                return fourthWeekSumCollection;
//            }
//        }

//        #endregion

//        #region Подсчёт суммы расходов за каждую неделю

//        private double sumForTheFirstWeek;
//        public double SumForTheFirstWeek {
//            get {
//                sumForTheFirstWeek = 0;
//                foreach (double d in FirstWeekSumCollection) {
//                    sumForTheFirstWeek += d;
//                }
//                return sumForTheFirstWeek;
//            }
//        }

//        private double sumForTheSecondWeek;
//        public double SumForTheSecondWeek {
//            get {
//                sumForTheSecondWeek = 0;
//                foreach (double d in SecondWeekSumCollection) {
//                    sumForTheSecondWeek += d;
//                }
//                return sumForTheSecondWeek;
//            }
//        }

//        private double sumForTheThirdWeek;
//        public double SumForTheThirdWeek {
//            get {
//                sumForTheThirdWeek = 0;
//                foreach (double d in ThirdWeekSumCollection) {
//                    sumForTheThirdWeek += d;
//                }
//                return sumForTheThirdWeek;
//            }
//        }

//        private double sumForTheFourthWeek;
//        public double SumForTheFourthWeek {
//            get {
//                sumForTheFourthWeek = 0;
//                foreach (double d in FourthWeekSumCollection) {
//                    sumForTheFourthWeek += d;
//                }
//                return sumForTheFourthWeek;
//            }
//        }



//        #endregion

//        #region Коллекции с остатками за каждую неделю по статьям

//        private ObservableCollection<double> firstWeekRestCollection = new ObservableCollection<double>();
//        public ObservableCollection<double> FirstWeekRestCollection {
//            get { return firstWeekRestCollection; }
//        }

//        private ObservableCollection<double> secondWeekRestCollection = new ObservableCollection<double>();
//        public ObservableCollection<double> SecondWeekRestCollection {
//            get { return secondWeekRestCollection; }
//        }

//        private ObservableCollection<double> thirdWeekRestCollection = new ObservableCollection<double>();
//        public ObservableCollection<double> ThirdWeekRestCollection {
//            get { return thirdWeekRestCollection; }
//        }

//        private ObservableCollection<double> fourthWeekRestCollection = new ObservableCollection<double>();
//        public ObservableCollection<double> FourthWeekRestCollection {
//            get { return fourthWeekRestCollection; }
//        }

//        #endregion

//        #region Подсчёт общего остатка для каждой недели

//        private double restByTheFirstWeekEnd;
//        public double RestByTheFirstWeekEnd {
//            get {
//                restByTheFirstWeekEnd = 0;
//                foreach (double d in FirstWeekRestCollection) {
//                    restByTheFirstWeekEnd += d;
//                }
//                return restByTheFirstWeekEnd;
//            }
//        }

//        private double restByTheSecondWeekEnd;
//        public double RestByTheSecondWeekEnd {
//            get {
//                restByTheSecondWeekEnd = 0;
//                foreach (double d in SecondWeekRestCollection) {
//                    restByTheSecondWeekEnd += d;
//                }
//                return restByTheSecondWeekEnd;
//            }
//        }

//        private double restByTheThirdWeekEnd;
//        public double RestByTheThirdWeekEnd {
//            get {
//                restByTheThirdWeekEnd = 0;
//                foreach (double d in ThirdWeekRestCollection) {
//                    restByTheThirdWeekEnd += d;
//                }
//                return restByTheThirdWeekEnd;
//            }
//        }

//        private double restByTheFourthWeekEnd;
//        public double RestByTheFourthWeekEnd {
//            get {
//                restByTheFourthWeekEnd = 0;
//                foreach (double d in FourthWeekRestCollection) {
//                    restByTheFourthWeekEnd += d;
//                }
//                return restByTheFourthWeekEnd;
//            }
//        }


//        #endregion

//        public event PropertyChangedEventHandler PropertyChanged;
//        public void OnPropertyChanged(string prop) {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
//        }

//        public TwentyEightDaysCollection() { }
//        public TwentyEightDaysCollection(DateTime firstDay, byte numberOfExpences, List<OnePlanExpence> planList) {

//            TwentyEightDays = new List<DayExpences>();
//            PlanList = planList;

//            for (int i = 0; i < 28; i++) {
//                TwentyEightDays.Add(new DayExpences(firstDay + TimeSpan.FromDays(i), numberOfExpences));
//            }

//            for (int i = 0; i < numberOfExpences; i++) {
//                firstWeekSumCollection.Add(0);
//                secondWeekSumCollection.Add(0);
//                thirdWeekSumCollection.Add(0);
//                fourthWeekSumCollection.Add(0);

//                firstWeekRestCollection.Add(PlanList[i].SumOfExpence);
//                secondWeekRestCollection.Add(PlanList[i].SumOfExpence);
//                thirdWeekRestCollection.Add(PlanList[i].SumOfExpence);
//                fourthWeekRestCollection.Add(PlanList[i].SumOfExpence);
//            }


            
            

//        }


//        public void ObserveCollectionsForSums() {

//            for (int j = 0; j < 7; j++) {
//                foreach (ExpenseItems col in TwentyEightDays[j].DayOutgoingsList)
//                    col.Collection.CollectionChanged += delegate {
//                        DoTheWeek_Number_Sums(1, firstWeekSumCollection);
//                        DoTheWeekRests();
//                        OnPropertyChanged("SumForTheFirstWeek");
//                        OnPropertyChanged("RestByTheFirstWeekEnd");
//                        OnPropertyChanged("RestByTheSecondWeekEnd");
//                        OnPropertyChanged("RestByTheThirdWeekEnd");
//                        OnPropertyChanged("RestByTheFourthWeekEnd");
//                    };
//            }

//            for (int j = 7; j < 14; j++) {
//                foreach (ExpenseItems col in TwentyEightDays[j].DayOutgoingsList)
//                    col.Collection.CollectionChanged += delegate {
//                        DoTheWeek_Number_Sums(2, secondWeekSumCollection);
//                        DoTheWeekRests();
//                        OnPropertyChanged("SumForTheSecondWeek");
//                        OnPropertyChanged("RestByTheSecondWeekEnd");
//                        OnPropertyChanged("RestByTheThirdWeekEnd");
//                        OnPropertyChanged("RestByTheFourthWeekEnd");
//                    };
//            }

//            for (int j = 14; j < 21; j++) {
//                foreach (ExpenseItems col in TwentyEightDays[j].DayOutgoingsList)
//                    col.Collection.CollectionChanged += delegate {
//                        DoTheWeek_Number_Sums(3, thirdWeekSumCollection);
//                        DoTheWeekRests();
//                        OnPropertyChanged("SumForTheThirdWeek");
//                        OnPropertyChanged("RestByTheThirdWeekEnd");
//                        OnPropertyChanged("RestByTheFourthWeekEnd");
//                    };
//            }

//            for (int j = 21; j < 28; j++) {
//                foreach (ExpenseItems col in TwentyEightDays[j].DayOutgoingsList)
//                    col.Collection.CollectionChanged += delegate {
//                        DoTheWeek_Number_Sums(4, fourthWeekSumCollection);
//                        DoTheWeekRests();
//                        OnPropertyChanged("SumForTheFourthWeek");
//                        OnPropertyChanged("RestByTheFourthWeekEnd");
//                    };
//            }

//        }

//        private ObservableCollection<double> DoTheWeek_Number_Sums(byte numOfWeek, ObservableCollection<double> col) {

//            for(int i = 0; i < col.Count; i++) {
//                col[i] = 0;
//            }

//            for (int i = 0; i < col.Count; i++) {
//                for (int j = (numOfWeek - 1) * 7; j < ((numOfWeek - 1) * 7) + 7; j++) {
//                    col[i] += TwentyEightDays[j].DayOutgoingsList[i].Sum;
//                }
//            }

//            return col;
//        }

//        private void DoTheWeekRests() {

//            for (int i = 0; i < firstWeekRestCollection.Count; i++) {
//                firstWeekRestCollection[i] = PlanList[i].SumOfExpence - FirstWeekSumCollection[i];
//                secondWeekRestCollection[i] = FirstWeekRestCollection[i] - SecondWeekSumCollection[i];
//                thirdWeekRestCollection[i] = SecondWeekRestCollection[i] - ThirdWeekSumCollection[i];
//                fourthWeekRestCollection[i] = ThirdWeekRestCollection[i] - FourthWeekSumCollection[i];
//            }
//        }


//    }
//}
