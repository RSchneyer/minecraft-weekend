#version 430

layout (location = 0) in vec3 position;
layout (location = 1) in vec2 uv;

uniform mat4 m;
uniform mat4 v;
uniform mat4 p;

layout (location = 1) out vec2 v_uv;
layout (location = 2) out vec3 v_viewpos;

void main() {
  
    gl_Position = p * v * m * vec4(position, 1.0);
    v_uv = uv;
    v_viewpos = ((v * m) * vec4(position, 1.0)).xyz;
}