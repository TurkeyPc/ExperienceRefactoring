using System.Collections.Generic;

namespace ExperienceRefactoring {
    class Customer {
        private string _name;
        private List<Rental> _rentals = new List<Rental>();

        public Customer(string name) {
            _name = name;
        }

        public void addRental(Rental arg) {
            _rentals.Add(arg);
        }
        public string getName() {
            return _name;
        }
        public string statement() {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + getName() + "\n";

            //一行ごとに金額を計算
            foreach(var each in _rentals) {
                double thisAmount = 0;
                switch (each.getMovie().getPriceCode()) {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.getDaysRented() > 2)
                            thisAmount += (each.getDaysRented() - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.getDaysRented() * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.getDaysRented() > 3)
                            thisAmount += (each.getDaysRented() - 3) * 1.5;
                        break;
                }
                //レンタルポイントを加算
                frequentRenterPoints++;
                //新作を二日以上借りた場合はボーナスポイント
                if ((each.getMovie().getPriceCode() == Movie.NEW_RELEASE) &&
                    each.getDaysRented() > 1) frequentRenterPoints++;

                //この貸し出しに関する数値の表示
                result += "\t" + each.getMovie().getTitle() + "\t" +
                    thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }
            //フッタ部分の追加
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() +
                " frequent renter points";
            return result;
        }
    }
}
