const divideFn = size => key => key % size

const multiplyFn = size => key => Math.floor(size * (key * 0.268124 % 1))

class HashTable {
    constructor(size, hashFn) {
        this.size = size
        this.fn = hashFn(size)
        this.items = new Array(size).fill(0).map(() => [])
    }
    add(key, value) {
        if (this.has(key)) return console.log(`Помилка: елемент з ключем ${key} вже існує`)
        this.items[this.fn(key)].push([key, value])
    }
    remove(key) {
        if (!this.has(key)) return console.log(`Помилка: елементу з ключем ${key} не існує`)
        this.items[this.fn(key)] = this.items[this.fn(key)].filter(item => item[0] !== key)
    }

    has(key) {
        return this.items[this.fn(key)].filter(item => item[0] === key).length !== 0
    }
    get(key) {
        if (!this.has(key)) return console.log(`Елементу з ключем ${key} не існує`)
        return this.items[this.fn(key)].find(item => item[0] === key)[1]
    }
}


         
