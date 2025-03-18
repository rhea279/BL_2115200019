let heads = 0, tails = 0;

while (heads < 11 && tails < 11) {
    let flip = Math.random();
    if (flip < 0.5) {
        heads++;
    } else {
        tails++;
    }
    console.log(`Heads: ${heads}, Tails: ${tails}`);
}

console.log((heads === 11 ? "Heads" : "Tails") + " wins!");
