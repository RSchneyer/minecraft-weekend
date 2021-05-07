#version 430

uniform sampler2D tex;
uniform float use_tex;
uniform vec2 uv_offset;

uniform vec4 color;
uniform vec4 fog_color;
uniform float fog_near;
uniform float fog_far;

// in (location = 0) vec4 gl_FragCoord;
layout (location = 1) in vec2 v_uv;
layout (location = 2) in vec3 v_viewpos;

layout (location = 0) out vec4 frag_color;
layout (location = 1) out vec4 frag_coord;

void main() {
  
    frag_color = color * ((use_tex * texture(tex, v_uv + uv_offset)) + ((1.0 - use_tex) * vec4(1.0)));
    frag_coord = gl_FragCoord;
}