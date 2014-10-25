# -*- coding: utf-8 -*-
# <nbformat>3.0</nbformat>

# <codecell>


# <codecell>


# <codecell>

import sys

prefix = 'public int[,] level = new int[,]{'
suffix = '};'

f = open ("spaceship.txt" , "r")

tr={'.':'0' , '-':'1' , '#':'2' , 'A':'3' , 'G':'4'}


# <codecell>


# <codecell>


# <codecell>

def translate (line):
    line=line.strip('\n')
    out="{"
    for c in line:
        out += tr[c]
        out += ','
        
    return out[:-1]+'}'

# <codecell>

def convert(filename):
    with open(filename, 'r') as f:
        lines = f.readlines()
        output = prefix
        output += ",\n".join([translate(line) for line in lines])
    print output+suffix

# <codecell>

convert("spaceship.txt")

# <codecell>


# <codecell>


if __name__=='__main__':
    if len(sys.argv) != 2:
        print("Usage: {} <inputfilename>")
        sys.exit()
    convert(sys.argv[1])

