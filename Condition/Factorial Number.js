let n = parseInt(process.argv[2]);
let factorial = 1;

for (let i = 1; i <= n; i++) {
    factorial *= i;
}

console.log(`${n}! =`, factorial);
