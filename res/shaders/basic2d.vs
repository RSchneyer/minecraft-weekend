#version 430

layout (location = 0) in vec3 position;
layout (location = 1) in vec2 uv;
layout (location = 2) in vec4 color;

uniform mat4 m;
uniform mat4 v;
uniform mat4 p;

layout (location = 1) out vec4 v_color;
layout (location = 2) out vec2 v_uv;

void main() {
  
    gl_Position = p * v * m * vec4(position, 1.0);
    v_color = color;
    v_uv = uv;
}