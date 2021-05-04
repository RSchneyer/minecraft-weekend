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
  vec4 color_temp;
    // color_temp = color * ((use_tex * texture(tex, v_uv + uv_offset)) + ((1.0 - use_tex) * vec4(1.0)));

    // // TODO: this is bad for performance
    // // if (color_temp.a < 0.001) {
    // //     discard;
    // // }
    
    // //float smoothstep_temp;
    // //smoothstep_temp = clamp((x - edge0 / (edge)))

    // vec3 viewpos_temp = v_viewpos;
    // //float fog = smoothstep(fog_near, fog_far, length(v_viewpos));
    // //float c_half = 0.5;
    // float length_temp = sqrt(viewpos_temp.x * viewpos_temp.x + viewpos_temp.y * viewpos_temp.y + viewpos_temp.z * viewpos_temp.z);
    // float fog = min(max((length_temp - fog_near) / (fog_far - fog_near), 0.0), 1.0);
    // fog = fog * fog * (3.0 - 2.0 * fog);
    // vec4 mix_result = color_temp * (1 - fog) + fog_color * fog;
    // frag_color = vec4(mix_result.rgb, color_temp.a);
    frag_color = vec4(0.0, 0.7, 1.0, 1.0);
    frag_coord = gl_FragCoord;
}