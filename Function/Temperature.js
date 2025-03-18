function convertTemperature(choice, temp) {
    switch (choice) {
        case 1: // Celsius to Fahrenheit
            if (temp < 0 || temp > 100) {
                console.log("Temperature out of range (0°C - 100°C)");
            } else {
                let degF = (temp * 9 / 5) + 32;
                console.log(`${temp}°C = ${degF.toFixed(2)}°F`);
            }
            break;
        case 2: // Fahrenheit to Celsius
            if (temp < 32 || temp > 212) {
                console.log("Temperature out of range (32°F - 212°F)");
            } else {
                let degC = (temp - 32) * 5 / 9;
                console.log(`${temp}°F = ${degC.toFixed(2)}°C`);
            }
            break;
        default:
            console.log("Invalid choice! Enter 1 for Celsius to Fahrenheit or 2 for Fahrenheit to Celsius.");
    }
}

// Example Usage:
let choice = parseInt(process.argv[2]);
let temperature = parseFloat(process.argv[3]);
convertTemperature(choice, temperature);
