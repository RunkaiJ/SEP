function multiplyNumeric(obj) {
    for (let key in obj) {
        let value = obj[key];
        if (typeof value == "number" && !Number.isNaN(value)) {
            obj[key] = value * 2;
        }
    }
}

let menu = {
    width: 200,
    height: 300,
    title: "My menu",
};

multiplyNumeric(menu);

console.log(menu);
