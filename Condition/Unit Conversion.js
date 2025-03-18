let choice = parseInt(process.argv[2]);
let value = parseFloat(process.argv[3]);

switch (choice) {
    case 1: console.log(value + " Feet = " + (value * 12) + " Inches"); break;
    case 2: console.log(value + " Feet = " + (value * 0.3048) + " Meters"); break;
    case 3: console.log(value + " Inches = " + (value / 12) + " Feet"); break;
    case 4: console.log(value + " Meters = " + (value * 3.28084) + " Feet"); break;
    default: console.log("Invalid choice! Enter 1 for Feet to Inch, 2 for Feet to Meter, 3 for Inch to Feet, 4 for Meter to Feet.");
}
