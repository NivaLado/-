X = [2, 3, 5]
Y = [1, 0, 4]

N = len(X)

mond = []

for i in range(N):
    vector = []
    for j in range(N):
        vector.append(X[j] ** i)
    mond.append(vector)

print('Van-der-mond \n')
print(mond)

A = [0] * N

for i in range(N - 1):
    m = i
    for j in range(i + 1, N):
        if (abs(mond[i][m]) < abs(mond[i][j])):
            m = j
    
    for k in range(i, N):
        c = mond[k][m]
        mond[k][m] = mond[k][i]
        mond[k][i] = c
    
    c = Y[m]
    Y[m] = Y[i]
    Y[i] = c

    for j in range(i+1, N):
        c = -mond[i][j] / mond[i][i]
        for k in range(i+1, N):
            mond[k][j] += c * mond[k][i]
        Y[j] += c * Y[i]
    
A[N-1] = Y[N-1] / mond[N-1][N-1]

for i in range(N -2, -1, -1):
    for k in range(i + 1, N):
        Y[i] = Y[i] - A[k] * mond[k][i]
    A[i] = Y[i] / mond[i][i]

print(A)
    