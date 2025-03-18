function isPalindrome(num) {
    let strNum = num.toString();
    let reversed = strNum.split("").reverse().join("");
    return strNum === reversed;
}

// Example Usage:
let num1 = parseInt(process.argv[2]);
let num2 = parseInt(process.argv[3]);

console.log(`${num1} is${isPalindrome(num1) ? "" : " not"} a palindrome`);
console.log(`${num2} is${isPalindrome(num2) ? "" : " not"} a palindrome`);
