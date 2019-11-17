def show(arr):
    for vector in arr:
        print(vector)
    print("\n")

def initMatrix(n):
    return [[0 for x in range(n)]  
    for y in range(n)]

A = [
    [2, -5, 3],
    [4, -2, 1],
    [1, 2, -3]
]

B = [-7, 0, 1]

n = len(A)

X = n * [0]
Y = n * [0]

L = initMatrix(n)
U = initMatrix(n)

for i in range(n):
    for j in range(n - (n - 1 - i)):
        sum = 0
        for k in range(j):
            sum +=  L[i][k] * U[k][j] 
        L[i][j] = A[i][j] - sum
    
    for j in range(n):
        sum = 0
        for k in range(i):
            sum  += L[i][k] * U[k][j]
        U[i][j] = (A[i][j] - sum) / L[i][i]

for i in range(n):
    sum = 0
    for k in range(i):
        sum += L[i][k] * Y[k]
    Y[i] = (1 / L[i][i])  * (B[i] - sum)

for i in range(n-1,-1,-1):
    sum = 0
    for k in range(i + 1, n):
        sum += U[i][k] * X[k]
    X[i] = Y[i] - sum

print("MATRIX A")
show(A)
print("Vector B")
print(B)

print("MATRIX L")
show(L)
print("MATRIX U")
show(U)

print("Result X")
print(X)