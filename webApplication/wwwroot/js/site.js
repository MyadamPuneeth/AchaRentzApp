$(document).ready(function () {
    // carsData is passed from the view as a JSON string, so we need to parse it into a JavaScript object
    var cars = JSON.parse(carsData);
    var carsDisplayed = 6;  // Initially displaying 6 cars
    var totalCars = cars.length;  // Get the total number of cars
    var increment = 3;  // Number of cars to show on each click

    // Show more cars when 'Show More' button is clicked
    $('#showMoreBtn').click(function () {
        var remainingCars = totalCars - carsDisplayed;
        var carsToShow = Math.min(increment, remainingCars);

        // Append new cars to the car container
        for (var i = 0; i < carsToShow; i++) {
            var carIndex = carsDisplayed + i;
            var car = cars[carIndex];

            // Dynamically append car partial view
            $('#carTilesContainer').append(`
            <div class="car-card">
                <div class="car-image">
                    <div class="car-rating">
                        <span class="rating-badge">
                            ${car.UserRating} <i class="fa fa-star"></i><p>|</p>
                            <span class="trips-count">${car.NumberOfTrips} Trips</span>
                        </span>
                    </div>
                </div>
                <div class="car-info">
                    <div class="main-car-info">
                        <h3 class="car-name">${car.Model}</h3>
                        <h6>${car.Transmission} . ${car.FuelType} . ${car.SeatingCapacity} Seats</h6>
                        <div class="car-pricing">
                            <div>
                                <span class="discounted-price">₹${car.RentalPricePerDay}/hr</span>
                                <span class="original-price">₹${(car.RentalPricePerDay * 1.12).toFixed(2)}/hr</span>
                            </div>
                            <div class="total-price">
                                ₹${(car.RentalPricePerDay * 30).toFixed(2)} <span class="fees-exclusion">(excluding fees)</span>
                            </div>
                        </div>
                    </div>
                    <p>--------------------------------------------------</p>
                    <div class="car-location">
                        <i class="fa fa-walking"></i> ${car.DistanceFromUser} km away
                    </div>
                    ${car.HasHomeDelivery ? '<div class="home-delivery-btn">Home Delivery</div>' : ''}
                </div>
            </div>
            `);
        }

        carsDisplayed += carsToShow;

        // Hide the 'Show More' button if all cars are displayed
        if (carsDisplayed >= totalCars) {
            $('#showMoreContainer').hide();
        }
    });
});
