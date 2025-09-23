
// Grab elements 
const bill = document.querySelector("#bill");
const tip = document.querySelector("#tip");
const tipLabel = document.querySelector("#tipLabel");
const people = document.querySelector("#people");
const total = document.querySelector("#total");
const per = document.querySelector("#perPerson");
const message = document.querySelector("#message");
const themeBtn = document.querySelector("#themeBtn");


function update() {
    const billValue = Number(bill.value);
    const tipValue = Number(tip.value);
    const peopleValue = Number(people.value);

    // Update tip label
    tipLabel.textContent = `Tip: ${tipValue}%`;

    // Validate input
    if (!billValue || billValue <= 0) {
        total.textContent = "0.00";
        per.textContent = "0.00";
        message.innerText = "Please enter a valid bill amount";
        return;
    }

    const tipAmount = billValue * (tipValue / 100);
    const totalAmount = billValue + tipAmount;
    const perPersonAmount = peopleValue > 0 ? totalAmount / peopleValue : totalAmount;

    total.textContent = totalAmount.toFixed(2);
    message.textContent = peopleValue > 1 ? "Split between " + peopleValue + " people" : "Single payer.";
    console.log(perPersonAmount);
    per.textContent = perPersonAmount.toFixed(2);
}

themeBtn.addEventListener("click", () => {
    document.documentElement.classList.toggle("dark");
});

[bill, tip, people].forEach(element => element.addEventListener("input", update));


update(); // Initial call to set values