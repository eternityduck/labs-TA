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
    if(this.root === null) {
      this.root = node
      node.parent = this.root
    } else this.addNode(this.root, node)
 
    return node
  }
  addNode(rootNode, node) {
    if(node.data < rootNode.data) {
      if(rootNode.left === null) {
        rootNode.left = node
        node.parent = rootNode
      }
      else this.addNode(rootNode.left, node)
    } else {
      if(rootNode.right === null) {
        rootNode.right = node
        node.parent = rootNode
      }
      else this.addNode(rootNode.right, node)
    }
  }
 
  search(data, node = this.root, printSteps = false) {
    if(node === this.root) process.stdout.write(`${node.data}`)
 
    if(node === null) {
      process.stdout.write(` -> нічого\n`)
      return null
    }
 
    if(data < node.data) {
      if(node.left?.data) process.stdout.write(` -> ${node.left.data}`)
      return this.search(data, node.left)
    }
 
    else if(data > node.data) {
      if(node.right?.data) process.stdout.write(` -> ${node.right.data}`)
      return this.search(data, node.right)
    }
 
    else {
      console.log('')
      return node
    }
  }
 
  print(node = this.root) {
    if(node !== null) {
      this.print(node.left)
      console.log(node.data)
      this.print(node.right)
    }
  }
}
 
const tree = new Tree()
tree.add(15)
tree.add(4)
tree.add(5)
tree.add(2)
tree.add(17)
tree.add(22)
tree.add(16)
tree.add(8)
tree.add(1)
tree.add(18)
tree.add(7)
tree.add(21)
tree.add(12)
tree.add(10)
tree.add(9)
tree.add(25)
 
;(async () => {
  const data = await prompt('Скільки золота потрібно? ')
  console.log('Шукаємо шлях до печери')
  const result = tree.search(+data, tree.root, true)
  if(!result) {
    console.log('Печеру з такою кількістю золота не знайдено. Викопуємо:')
    tree.add(+data)
    tree.search(+data, tree.root, true)
  }
})()
 
