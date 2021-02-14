using System;

namespace ExperienceRefactoring {
    class Program {
        static void Main(string[] args) {
            //for test
            var target = new Customer("ore");
            target.addRental(new Rental(new Movie("kimetu no yaiba", Movie.NEW_RELEASE), 5));
            target.addRental(new Rental(new Movie("doraemon", Movie.CHILDRENS), 7));
            target.addRental(new Rental(new Movie("garupan ha iizo", Movie.REGULAR), 11));
            target.addRental(new Rental(new Movie("turf topic 1993", Movie.REGULAR), 13));

            Console.WriteLine(target.statement());
            /*
                Rental Record for ore
                        kimetu no yaiba 15
                        doraemon        7.5
                        garupan ha iizo 15.5
                        turf topic 1993 18.5
                Amount owed is 56.5
                You earned 5 frequent renter points
            */
        }
    }
}
