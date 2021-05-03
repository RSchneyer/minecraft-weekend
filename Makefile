UNAME_S = $(shell uname -s)

CC = gcc
CFLAGS = -std=c11 -Wall -Wextra -Wpedantic -Wstrict-aliasing
CFLAGS += -Wno-pointer-arith -Wno-unused-parameter 
CFLAGS += -Ilib/cglm/include -Ilib/glad/include -Ilib/glfw/include -Ilib/stb -Ilib/noise 
LDFLAGS = lib/glad/src/glad.o lib/cglm/.libs/libcglm.a lib/noise/libnoise.a -lm 

ifdef SIMPLEGL
LDFLAGS += -L$(CDIR)/utils/lib64 -lglfw -lGLU -lGL -lsimpleGLU
endif


ifeq (${BUILD_TYPE}, DEBUG)
CFLAGS += -O0 -g
else
CFLAGS	+= -O2
endif

ifeq (${BUILD_SANITIZE}, TRUE)
CFLAGS += -fsanitize=address 
LDFLAGS += -fsanitize=address 
endif

# GLFW required frameworks on OSX
ifeq ($(UNAME_S), Darwin)
	LDFLAGS += -framework OpenGL -framework IOKit -framework CoreVideo -framework Cocoa
endif

ifeq ($(UNAME_S), Linux)
	LDFLAGS += -ldl -lpthread -lglfw
endif

SRC  = $(wildcard src/**/*.c) $(wildcard src/*.c) $(wildcard src/**/**/*.c) $(wildcard src/**/**/**/*.c)
OBJ  = $(SRC:.c=.o)
BIN = bin

.PHONY: all clean

all: dirs game

libs:
	git submodule init && git submodule update
	cd lib/cglm && dos2unix autogen.sh && sh autogen.sh && ./configure && make && make check
	cd lib/glad && $(CC) -o src/glad.o -Iinclude -c src/glad.c
	cd lib/noise && make

dirs:
	mkdir -p ./$(BIN)

run: all
	$(BIN)/game

game: $(OBJ)
	$(CC) -o $(BIN)/game $^ $(LDFLAGS)
	dos2unix res/shaders/*

%.o: %.c
	$(CC) -o $@ -c $< $(CFLAGS)

clean:
	rm -rf $(BIN) $(OBJ)
