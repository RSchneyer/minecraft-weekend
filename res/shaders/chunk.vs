#version 430

layout (location = 0) in vec3 position;
layout (location = 1) in vec2 uv;
//layout (location = 2) in uint color;

//TODO......
//const uint color = 0xFFFFFU;

uniform mat4 m;
uniform mat4 v;
uniform mat4 p;

uniform vec4 sunlight_color;

// should match enum Direction in direction.h
const uint NORTH = 0U;
const uint SOUTH = 1U;
const uint EAST = 2U;
const uint WEST = 3U;
const uint UP = 4U;
const uint DOWN = 5U;

layout (location = 1) out vec4 v_color;
layout (location = 2) out vec2 v_uv;
layout (location = 3) out vec3 v_viewpos;

void main() {
    
    gl_Position = p * v * m * vec4(position, 1.0);
    v_color = vec4(1.0);
    v_uv = uv;
    v_viewpos = ((v * m) * vec4(position, 1.0)).xyz;
}