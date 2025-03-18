var val;
var datatype = typeof val;

console.log("Value: "+val);
console.log("Data Type:"+datatype);

var val = 0;
var datatype = typeof val;

console.log("Value: "+val);
console.log("Data Type:"+datatype);

var val = 10n;
var datatype = typeof val;

console.log("Value: "+val);
console.log("Data Type:"+datatype);

var val = true;
var datatype = typeof val;

console.log("Value: "+val);
console.log("Data Type:"+datatype);

var val = "foo";
var datatype = typeof val;

console.log("Value: "+val);
console.log("Data Type:"+datatype);

var datatype = typeof Symbol("id");
console.log("Data Type:"+datatype);

var datatype = typeof Math;
console.log("Data Type:"+datatype);

var datatype = typeof null;
console.log("Data Type:"+datatype);

let sayHi = function(){ sayHi = f()
    console.log.apply("Say Hi");
};
var datatype = typeof sayHi;
console.log("Data Type:"+datatype);