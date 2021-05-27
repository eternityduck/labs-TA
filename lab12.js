import {
    sort as LSD
} from './lsd-sort'
import {
    sort as MSD
} from './msd-sort'
import * as fs from 'fs/promises'
import {
    avg,
    genArray,
    measureTime
} from './utils'
const MES = 5,
    SIZE = 10 ** 7,
    LEN = 30;
(async () => {
    measureFor('LSD', LSD)
    measureFor('MSD', MSD)
})()
async function measureFor(label = '', fn = () => {}) {
    const data = []
    for (let size = 0; size <= SIZE; size += Math.floor(SIZE / LEN)) {
        const array = genArray(size)
        const getArray = () => [...array]
        const time = []
        for (let i = 0; i < MES; i++) {
            const ms = measureTime(() => fn(getArray()), 'LSD', false)
            time.push(ms)
        }
        console.log(`${label}: ${size} el.`)
        data.push([size, avg(time)])
    }
    await fs.writeFile(`${label}.txt`, data.map((x) => x.join(' ')).join('\n'))
}
export function genArray(N = 10 ** 7) {
    const arr = new Array(N)
    for (let i = 0; i < N; i++) arr[i] = Math.floor(Math.random() * 4294967295)
    return arr
}
export function measureTime(fn = () => {}, label = '', printTime = true) {
    const start = new Date()
    fn()
    const end = new Date()
    printTime &&
        console.log(
            `Elapsed time (${label}): ${((end - start) / 1000).toLocaleString('uk'
)}s`
        )
    return end - start
}
export function avg(array) {
    return array.reduce((a, b) => a + b, 0) / array.length
}

function sort(array, radix) {
    if (array.length === 0) {
        return array
    }
    radix = radix || 10
    let minValue = array[0]
    let maxValue = array[0]
    for (let i = 1; i < array.length; i++) {
        if (array[i] < minValue) {
            minValue = array[i]
        } else if (array[i] > maxValue) {
            maxValue = array[i]
        }
    }
    let exponent = 1
    while ((maxValue - minValue) / exponent >= 1) {
        array = countingSortByDigit(array, radix, exponent, minValue)
        exponent *= radix
    }
    return array
}

function countingSortByDigit(array, radix, exponent, minValue) {
    let i
    let bucketIndex
    let buckets = new Array(radix)
    let output = new Array(array.length)
    for (i = 0; i < radix; i++) {
        buckets[i] = 0
    }
    for (i = 0; i < array.length; i++) {
        bucketIndex = Math.floor(((array[i] - minValue) / exponent) % radix)
        buckets[bucketIndex]++
    }
    for (i = 1; i < radix; i++) {
        buckets[i] += buckets[i - 1]
    }
    for (i = array.length - 1; i >= 0; i--) {
        bucketIndex = Math.floor(((array[i] - minValue) / exponent) % radix)
        output[--buckets[bucketIndex]] = array[i]
    }
    for (i = 0; i < array.length; i++) {
        array[i] = output[i]
    }
    return array
}
export {
    sort
}
const last = new Uint32Array(256)
const pointer0 = new Uint32Array(256)
const pointer8 = new Uint32Array(256)
const pointer16 = new Uint32Array(256)
const pointer24 = new Uint32Array(256)

function sort(arr, start = 0, end = arr.length, shift = 24) {
    const ptr =
        shift === 0 ?
        pointer0 :
        shift === 8 ?
        pointer8 :
        shift === 16 ?
        pointer16 :
        pointer24
    for (let x = start; x < end; ++x) last[(arr[x] >> shift) & 0xff]++
    last[0] += start
    ptr[0] = start
    for (let x = 1; x < 256; ++x) {
        ptr[x] = last[x - 1]
        last[x] += last[x - 1]
    }
    for (let x = 0; x < 256; ++x) {
        let i = ptr[x]
        while (i !== last[x]) {
            let value = arr[i],
                y
            while ((y = (value >> shift) & 0xff) !== x) {
                value = arr[ptr[y]]
                swap(arr, i, ptr[y]++)
            }
            i++
        }
        ptr[x] = i
        last[x] = 0
    }
    if (shift === 0) return arr
    for (let x = 0; x < 256; ++x) {
        const i = x > 0 ? ptr[x - 1] : start
        const j = ptr[x]
        if (j - i > 64) {
            sort(arr, i, j, shift - 8)
        } else {
            insertionSort(arr, i, j)
        }
    }
    return arr
}

function insertionSort(arr, start, end) {
    for (let x = start + 1; x < end; ++x) {
        for (let y = x; y > start && arr[y - 1] > arr[y]; y--) swap(arr, y, y - 1)
    }
}

function swap(arr, i, j) {
    const temp = arr[i]
    arr[i] = arr[j]
    arr[j] = temp
}
export {
    sort
}
