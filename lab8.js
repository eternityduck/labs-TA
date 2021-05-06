const prompt = require('async-prompt')
 
class Node {
  constructor(data = null) {
    this.data = data
    this.parent = this.left = this.right = null
  }
}
 
class Tree {
  root = null
 
  add(data) {
    const node = new Node(data)
    if (this.root === null) {
      this.root = node
      node.parent = this.root
    } else this.addNode(this.root, node)
 
    return node
  }
  addNode(rootNode, node) {
    if (node.data < rootNode.data) {
      if (rootNode.left === null) {
        rootNode.left = node
        node.parent = rootNode
      } else this.addNode(rootNode.left, node)
    } else {
      if (rootNode.right === null) {
        rootNode.right = node
        node.parent = rootNode
      } else this.addNode(rootNode.right, node)
    }
  }
 
  search(data, node = this.root) {
    if (node === this.root) process.stdout.write(`${node.data}`)
 
    if (node === null) {
      process.stdout.write(` -> нічого\n`)
      return null
    }
 
    if (data < node.data) {
      if (node.left?.data) process.stdout.write(` -> ${node.left.data}`)
      return this.search(data, node.left)
    } else if (data > node.data) {
      if (node.right?.data) process.stdout.write(` -> ${node.right.data}`)
      return this.search(data, node.right)
    } else {
      console.log('')
      return node
    }
  }
 
  getArray(node = this.root) {
    const result = []
 
    if (node !== null) {
      result.push(this.getArray(node.left))
      result.push(node.data)
      result.push(this.getArray(node.right))
    }
 
    return result.flat()
  }
 
  setBalanced(from = []) {
    while (from.length !== 0) {
      const sorted = from.sort((a, b) => a - b)
      const mid = Math.floor(from.length / 2)
      this.add(sorted[mid])
      from.splice(from.indexOf(sorted[mid]), 1)
    }
  }
 
  clear(node = this.root) {
    if (node !== null) {
      this.clear(node.left)
      this.clear(node.right)
      node.left = node.right = null
      if (node === this.root) this.root = null
      else node = null
    }
  }
 
  addBalanced(data) {
    const array = this.getArray()
    array.push(data)
    this.clear()
    this.setBalanced(array)
  }
 
  print(node = this.root) {
    if (node !== null) {
      this.print(node.left)
      console.log(node.data)
      this.print(node.right)
    }
  }
}
 
const tree = new Tree()
tree.setBalanced([15, 4, 5, 2, 17, 22, 16, 8, 1, 18, 7, 21, 12, 10, 9, 25])
;(async () => {
  const data = await prompt('Скільки золота потрібно? ')
  console.log('Шукаємо шлях до печери')
  const result = tree.search(+data, tree.root)
  if (!result) {
    console.log('Печеру з такою кількістю золота не знайдено. Викопуємо:')
    tree.addBalanced(+data)
    tree.search(+data, tree.root)
  }
})()
