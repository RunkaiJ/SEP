let salaries = {
    John: 100,
    Ann: 160,
    Pete: 130,
};
let totalSalary = 0;

for (let key in salaries) {
    totalSalary += salaries[key];
}

console.log(totalSalary);
