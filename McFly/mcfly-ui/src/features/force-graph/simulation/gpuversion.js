const gpu = new GPU();
const input = GPU.input;
const n = 2000;
const masses = [];
const xs = [];

for(let i = 0; i < n; i++){
  masses.push((Math.random() * 100) | 0)
  xs.push((Math.random() * 5000) | 0)
}

function slow(a, b) {
  const ret = [];
  for(let i = 0; i < n; i++) {
    const newRow = [];
    ret.push(newRow);
    for(let j = 0; j < n; j++) {
      if(j == i) continue;
      const d = b[i] - b[j];
      newRow[j] = (a[i] * a[j]) / (d * d);
    }
  }
  return ret;
}

const calc = gpu.createKernel(function(a, b) {
  if(this.thread.x == this.thread.y) 
  {
    return 0;
  }
  let m1 = a[this.thread.x];
  let m2 = a[this.thread.y];
  let x1 = b[this.thread.x];
  let x2 = b[this.thread.y];
  let d = x1 - x2;
  return (m1 * m2) / (d * d);
}, {
constants: { size: n },
output: [n, n]
});

calc.setOutputToTexture(true);

function printMatrix(matrix){
  for(let i = 0; i < n; i++) {
    const row = matrix[i];
    if(Array.isArray(row))
      console.log(row.join("\t\t"));
    else
      console.log(row);
  } 
}

const slowStart = new Date();
slow(masses, xs);
const slowEnd = new Date();
console.log(`Slow: ${slowEnd - slowStart}ms`);

const gpuStart = new Date();
const res = calc(masses, xs);
const arr = res.toArray(gpu);
const gpuEnd = new Date();
console.log(`GPU: ${gpuEnd - gpuStart}ms`)
console.log(`${arr.length}x${arr[0].length}`)