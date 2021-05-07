#version 430

uniform vec4 color;

//layout (location = 0) in vec4 gl_FragCoord

layout (location = 0) out vec4 frag_color;
layout (location = 1) out vec4 frag_coord;

void main() {
  
    frag_color = color;
    frag_coord = gl_FragCoord;
}