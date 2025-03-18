let number = parseInt(process.argv[2]);

if (number === 1) console.log("Unit");
else if (number === 10) console.log("Ten");
else if (number === 100) console.log("Hundred");
else if (number === 1000) console.log("Thousand");
else if (number === 10000) console.log("Ten Thousand");
else if (number === 100000) console.log("Lakh");
else console.log("Invalid input! Enter numbers like 1, 10, 100, 1000, etc.");
