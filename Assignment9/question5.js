let names = ["James", "Brennie"];
console.log(names);
names.push("Robert");
console.log(names);
let mid = names.length / 2;
names.splice(mid, 1, "Calvin");
console.log(names);
names.splice(0, 1);
console.log(names);
names.splice(0, 0, "Rose", "Regal");
console.log(names);
