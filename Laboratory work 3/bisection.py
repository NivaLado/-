def f(x):
    return (2 ** (3 * x))

iteration = 0
a = 1
b = 4
epsilon = 0.0001

while abs(b - a) > epsilon:
    iteration += 1
    c = (a + b) / 2
    if (f(a) * f(c) > 0):
        a = c
    else:
        b = c

print('X: ' + str(c) + ',  iterations number: ' + str(iteration))
print('Convergence parameter: ' + str((b - a) / iteration))
