const divideFn = size => key => key % size
const multiplyFn = size => key => 1 + (Math.floor(size * (key * 0.726218124 % 1))) % (size - 1)
 
class HashTable {
  constructor(size, fn, method = 'linear') {
    this.size = size
    this.fn = fn(size)
    this.items = new Array(size)
    this.method = ['linear', 'double'].includes(method) ? method : 'linear'
    this.multiply = multiplyFn(size)
  }
 
  add(key, value) {
    if(!this.items.includes(undefined)) return console.log('Помилка: таблиця переповнена')
 
    const hash = this.fn(key),
      offset = this.method === 'double' ? this.multiply(key) : 1
 
    let index
    for(
      index = hash;
      this.items[index] !== undefined;
      index = (index + offset) % this.size
    )
      if(this.items[index][0] === key) return console.error(`Помилка: елемент з ключем ${key} вже існує`)
 
    return this.items[index] = [key, value]
  }
 
  remove(key) {
    const index = this.find(key)
    if(index === undefined) return console.error(`Помилка: елемент з ключем ${key} не знайдено`)
 
    this.items[index] = undefined
    return true
  }
 
  find(key) {
    const hash = this.fn(key),
      offset = this.method === 'double' ? this.multiply(key) : 1
 
    let index
    for(
      index = hash;
      this.items[index] !== undefined;
      index = (index + offset) % this.size
    )
      if(this.items[index][0] === key) return index
  }
}
