let money = 100, bets = 0, wins = 0;
const goal = 200;

while (money > 0 && money < goal) {
    bets++;
    let betResult = Math.random(); // 50% chance to win or lose
    if (betResult < 0.5) {
        money--; // Lost 1 Rs
    } else {
        money++; // Won 1 Rs
        wins++;
    }
}

console.log(`Final Money: Rs ${money}`);
console.log(`Total Bets Made: ${bets}`);
console.log(`Total Wins: ${wins}`);
