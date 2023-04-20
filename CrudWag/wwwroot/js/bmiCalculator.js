"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/bmiCalculatorHub").build();

connection.on("BMICalculated", function (bmi) {
    const resultElement = document.getElementById("bmiResult");
    resultElement.textContent = "Your BMI is " + bmi.toFixed(1);
});

document.getElementById("calculateButton").addEventListener("click", function () {
    const heightElement = document.getElementById("heightInput");
    const weightElement = document.getElementById("weightInput");

    const data = {
        height: heightElement.value,
        weight: weightElement.value
    };

    connection.invoke("CalculateBMI", data)
        .catch(function (err) {
            console.error(err);
        });
});