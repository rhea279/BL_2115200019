let numbers = [];
for (let i = 0; i < 5; i++) {
    numbers.push(Math.floor(Math.random() * (999 - 100 + 1)) + 100);
}

let min = numbers[0], max = numbers[0];

for (let i = 1; i < numbers.length; i++) {
    if (numbers[i] < min) {
        min = numbers[i];
    }
    if (numbers[i] > max) {
        max = numbers[i];
    }
}

console.log("Numbers:", numbers);
console.log("Minimum:", min);
console.log("Maximum:", max);
